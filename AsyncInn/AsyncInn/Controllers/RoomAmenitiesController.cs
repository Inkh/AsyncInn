using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        private readonly AsyncInnDbContext _context;
        private readonly IRoom _room;

        public RoomAmenitiesController(AsyncInnDbContext context, IRoom room)
        {
            _context = context;
            _room = room;
        }

        // GET: RoomAmenities
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenities).Include(r => r.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int? RoomID, int? AmenitiesID)
        {
            if (RoomID == null || AmenitiesID == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(r => r.Amenities)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomID == RoomID && m.AmenitiesID == AmenitiesID);
            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        // GET: RoomAmenities/Edit/5
        public async Task<IActionResult> Edit(int? RoomID, int? AmenitiesID)
        {
            if (RoomID == null || AmenitiesID == null)
            {
                return NotFound();
            }

            var roomAmenities = await _context.RoomAmenities
                .Include(h => h.Amenities)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.RoomID == AmenitiesID && m.RoomID == RoomID);

            if (roomAmenities == null)
            {
                return NotFound();
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name ", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        // POST: RoomAmenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (id != roomAmenities.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmenities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmenitiesExists(roomAmenities.RoomID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmenitiesID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenities.AmenitiesID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", roomAmenities.RoomID);
            return View(roomAmenities);
        }

        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? RoomID, int? AmenitiesID)
        {
            if (RoomID == null || AmenitiesID == null)
            {
                return NotFound();
            }

            var roomAmenities = await _room.GetRoomAmenities(RoomID, AmenitiesID);

            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(roomAmenities);
        }

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int RoomID, int AmenitiesID)
        {
            var roomAmenities = await _room.GetRoomAmenities(RoomID, AmenitiesID);
            _context.RoomAmenities.Remove(roomAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenitiesExists(int id)
        {
            return _context.RoomAmenities.Any(e => e.RoomID == id);
        }
    }
}

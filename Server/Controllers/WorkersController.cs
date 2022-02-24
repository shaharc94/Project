using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeProject.Server.Data;
using HomeProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HomeProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly DataContext _context;
        public WorkersController(DataContext context)
        {
            _context = context;
        }
        // localhost:5001/api/Workers
        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            //List<Worker> WorkersList = await _context.Workers.ToListAsync();
            List<Worker> WorkersList = new List<Worker>();
            WorkersList = await _context.Workers.ToListAsync();
            return Ok(WorkersList);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetWorker(int Id)
        {
 //Worker myWorker = await _context.Workers.FirstOrDefaultAsync(w => w.ID == Id);
            Worker myWorker = new Worker();
            myWorker = await _context.Workers.FirstOrDefaultAsync(w => w.ID == Id);
            if (myWorker != null)
            {
                return Ok(myWorker);
            }
            else
            {
                return BadRequest("No such worker");
            }
        }
        [HttpGet("bySalary/{mySalary}")]
        public async Task<IActionResult> GetWorkersBySalary(double mySalary)
        {
            List<Worker> mySalWorkers = new List<Worker>();
            mySalWorkers = await _context.Workers.Where(w => w.Salary > mySalary).ToListAsync();
            if (mySalWorkers.Count > 0)
            {
                return Ok(mySalWorkers);
            }
            else
            {
                return BadRequest("No workers for this salary");
            }
        }
        [HttpPost("insert")]
        public async Task<IActionResult> AddWorker(Worker newWorker)
        {
            if(newWorker != null)
            {
                _context.Workers.Add(newWorker);
                await _context.SaveChangesAsync();

                return Ok(newWorker);
            }
            else
            {
                return BadRequest("user did not send");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            Worker WorkerToDelete = await _context.Workers.FirstOrDefaultAsync(W => W.ID == id);

            if (WorkerToDelete != null)
            {
                _context.Workers.Remove(WorkerToDelete);
                await _context.SaveChangesAsync();

                return Ok(true);
            }
            else
            {
                return BadRequest("no such worker");
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateWorker(Worker workerToUpdate)
        {
            Worker WorkerFromDB = await _context.Workers.FirstOrDefaultAsync(w => w.ID == workerToUpdate.ID);

            if (WorkerFromDB != null)
            {
                WorkerFromDB.FullName = workerToUpdate.FullName;
                WorkerFromDB.Department = workerToUpdate.Department;
                WorkerFromDB.Salary = workerToUpdate.Salary;

                await _context.SaveChangesAsync();

                return Ok(WorkerFromDB);

            }
            else
            {
                return BadRequest("no such worker");
            }
        }
    }
}
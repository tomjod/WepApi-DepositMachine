using Domain.Entities.DepositMachines;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Machines
{
    public class DepositMachineRepository : IDepositMachineRepository
    {
        private readonly AppDbContext _context;

        public DepositMachineRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateMachine(DepositMachine machine)
        {
            _context.Add(machine);
        }

        public async Task<DepositMachine?> GetByIdAsync(
            DepositMachineId Id, 
            CancellationToken cancellation) =>
         await _context.Set<DepositMachine>()
            .FirstOrDefaultAsync(m => m.Id == Id);
    }
}

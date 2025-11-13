using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeRentACarAvaibleToFalse(int id)
        {
            var values = _context.RentACars.Where(x => x.RentACarID == id).FirstOrDefault();
            values.Avaible = false;
            _context.SaveChanges();
        }

        public void ChangeRentACarAvaibleToTrue(int id)
        {
            var values = _context.RentACars.Where(x => x.RentACarID == id).FirstOrDefault();
            values.Avaible = true;
            _context.SaveChanges();
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = await _context.RentACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }

        public List<RentACar> GetRentACarByCarNameLocationNameQuery()
        {
            var values = _context.RentACars.Include(X => X.Car).ThenInclude(y => y.Brand).Include(z=>z.Location).ToList();
            return values;
        }

        public RentACar GetRentACarByIDCarNameLocationNameQuery(int id)
        {
            var value = _context.RentACars.Where(x => x.RentACarID == id).Include(X => X.Car).ThenInclude(y => y.Brand).Include(z => z.Location).FirstOrDefault();
            return value;
        }
    }
}

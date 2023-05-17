﻿using LateosDB.Entities.AppContext;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LateosDB.DataAccess
{
    public class ProductoDAL
    {
        
            private static ProductoDAL _instance;

            public static ProductoDAL Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new ProductoDAL();
                    }
                    return _instance;

                }
            }


        public List<Producto> SellectAll()
        {
            List<Producto> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.productos.Include(x => x.Estado).ToList();
                result = _context.productos.Include(x => x.Category).ToList();
               
            }
            return result;
        }

        public Producto SellectById(int id)
        {
            Producto result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.productos
                    .FirstOrDefault(x => x.IdProducto == id);
            }

            return result;


        }


        public bool Insert(Producto entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.productos.FirstOrDefault(x => x.IdProducto.Equals(entity.IdProducto));
                if (query == null)
                {
                    _context.productos.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(Producto entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                var query = _context.productos.FirstOrDefault(x => x.IdProducto.Equals(entity.IdProducto));


                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }


        }








    }
}
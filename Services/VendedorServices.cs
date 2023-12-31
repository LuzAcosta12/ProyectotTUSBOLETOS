﻿using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectotTUSBOLETOS.Services
{
    class VendedorServices
    {
        Usuario user = new Usuario();
        public List<Evento> GetEventos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                    List<Evento> eventos = new List<Evento>();

                    return _context.Eventos.ToList();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }

        public decimal Calcular(int ID, int cantidad)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Evento evento = new Evento();
                    evento = _context.Eventos.Find(ID);
                    decimal precio = evento.Precio;
                    decimal total = precio * cantidad;
                    return total;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }

        public void Ordenar(int IDEvento, int cantidad, decimal total)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Venta venta = new Venta();
                    Evento evento = new Evento();
                    evento = _context.Eventos.Find(IDEvento);
                    venta.Cantidad = cantidad;
                    venta.Total = total;
                    venta.Fecha = DateTime.Now;
                    venta.FkEvento = IDEvento;
                    venta.FkUsuario = user.PkUsuario;

                    _context.Ventas.Add(venta);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }

        public void PasarDatos(Usuario usuario)
        {
            user.PkUsuario = usuario.PkUsuario;
        }

        public string Saludo()
        {
            string texto = $"Bienvenid@ ";
            return texto;
        }
    }
}

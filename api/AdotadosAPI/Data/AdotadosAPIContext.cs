using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdotadosDTO;

namespace AdotadosAPI.Data
{
    public class AdotadosAPIContext : DbContext
    {
        public AdotadosAPIContext (DbContextOptions<AdotadosAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AdotadosDTO.AnimalDTO> AnimalDTO { get; set; } = default!;
        public DbSet<AdotadosDTO.ClienteDTO> ClienteDTO { get; set; } = default!;
        public DbSet<AdotadosDTO.FuncionarioDTO> FuncionarioDTO { get; set; } = default!;
        public DbSet<AdotadosDTO.AdotadoDTO> AdotadoDTO { get; set; } = default!;
        public DbSet<AdotadosDTO.TipoFuncionarioDTO> TipoFuncionarioDTO { get; set; } = default!;
        public DbSet<AdotadosDTO.TipoAnimalDTO> TipoAnimalDTO { get; set; } = default!;
    }
}

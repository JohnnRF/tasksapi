using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext: DbContext{

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas  {get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){


        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){ CategoriaId=Guid.Parse("ea5d5b3d-fec5-4c2a-90d7-70adb5152919"), Nombre = "Actividades pendientes", Peso=20 });
        categoriasInit.Add(new Categoria(){ CategoriaId=Guid.Parse("95abfa31-071e-42a7-a476-aee7f43960f0"), Nombre = "Actividades personales", Peso=50 });

        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("categoria");
            categoria.HasKey(c => c.CategoriaId);

            categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(c  => c.Descripcion).IsRequired(false);
            categoria.Property(c  => c.Peso);

            categoria.HasData(categoriasInit);
            
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea(){ TareaId=Guid.Parse("e25b11e2-9270-4f3f-bd41-366b47f3728f"), CategoriaId =Guid.Parse("ea5d5b3d-fec5-4c2a-90d7-70adb5152919"), PrioridadTarea=Prioridad.Media, Titulo = "Pago de servicios públicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea(){ TareaId=Guid.Parse("85fce2de-3d80-491c-bd54-ee8c2c1fa1c9"), CategoriaId =Guid.Parse("95abfa31-071e-42a7-a476-aee7f43960f0"), PrioridadTarea=Prioridad.Baja, Titulo = "Terminar de ver película en Netflix", FechaCreacion = DateTime.Now });
 
        modelBuilder.Entity<Tarea>(tarea => {

            tarea.ToTable("tarea");
            tarea.HasKey(t => t.TareaId);
            
            tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);

            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);

            tarea.HasData(tareasInit);
        });
    }

}
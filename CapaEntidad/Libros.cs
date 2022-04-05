using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public class Libros
	{
		public int Id { get; set; }
		public string SignaturaTopografica { get; set; }
		public string Nombre { get; set; }
		public decimal ISB { get; set; }
		public int BibliografiaId { get; set; } // foreign key
		public string Bibliografia { get; set; }
		public string Autores { get; set; }
		public string Descripcion { get; set; }
		public string Ciencia { get; set; }
		public string Editora { get; set; }
		public bool Estado  { get; set; }
		public string Idioma { get; set; }
		public string year { get; set; }
	}
}

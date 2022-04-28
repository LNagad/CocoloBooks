using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public decimal ISBN { get; set; }
		public string Descripcion { get; set; }
		public int BibliografiaId { get; set; } // foreign key
		public string Bibliografia { get; set; }
		public int CienciaId { get; set; } // foreign key
		public string Ciencia { get; set; }
		public int AutorId { get; set; } // foreign key
		public string Autores { get; set; }
		public int EditoraId { get; set; } // foreign key
		public string Editora { get; set; }
		public int IdiomaId { get; set; } // foreign key
		public string Idioma { get; set; }
		public string RutaImagen { get; set; }
		public string NombreImagen { get; set; }
		public string year { get; set; }
		public bool Estado  { get; set; }

		public string Base64 { get; set; }
		public string ExtensionImagen { get; set; }
	}
}

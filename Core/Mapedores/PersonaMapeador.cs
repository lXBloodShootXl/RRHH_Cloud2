using RRHH.Core.DTOs;
using RRHH.Core.Models;
namespace RRHH.Core.Mapedores
{
    public static class PersonaMapeador
    {
        public static PersonaDTO toPersonaDTO(this Persona persona)
        {
            return new PersonaDTO()
            {
                CI = persona.CI,
                Nombre = persona.Nombre,
                ApellidoPaterno = persona.ApellidoPaterno,
                ApellidoMaterno = persona.ApellidoMaterno,
                FechaNacimiento = persona.FechaNacimiento,
                Sexo = persona.Sexo
                /*PersonaTelefonos = persona.PersonaTelefonos
                    .Select(x => x.toPersonaTelefonoDTO())
                    .ToList()
                ,
                PersonaEmails = persona.PersonaEmails
                    .Select(x => x.toPersonaEmailDTO())
                    .ToList(),
                Empleado = persona.Empleado.toEmpleadoDTO()*/
            };
        }
    }
}

namespace RRHH.Core.Models
{
    public class PagoRequest
    {
        public string Tipo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Monto { get; set; } = 0;
        public string Beneficiario { get; set; } = null!;
        public string CuentaBancariaDestino { get; set; } = null!;
    }

}


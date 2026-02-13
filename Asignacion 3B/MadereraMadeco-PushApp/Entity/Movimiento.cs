using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Movimiento
{
    [XmlAttribute("tipo")]
    public string Tipo { get; set; } 

    [XmlElement("cuentaContable")]
    public string CuentaContable { get; set; }

    [XmlElement("monto")]
    public decimal Monto { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

[XmlRoot("asientoActivoFijo")]
public class AsientoActivoFijo
{
    [XmlAttribute("moneda")]
    public string Moneda { get; set; } = "DOP";

    [XmlAttribute("idTransaccion")]
    public string IdTransaccion { get; set; }

    [XmlElement("numeroAsiento")]
    public string NumeroAsiento { get; set; }

    [XmlElement("descripcionAsiento")]
    public string DescripcionAsiento { get; set; }

    [XmlElement("fechaAsiento", DataType = "date")]
    public DateTime FechaAsiento { get; set; }

    [XmlArray("movimientos")]
    [XmlArrayItem("movimiento")]
    public List<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for nodoUsuariotxt
/// </summary>
public class nodoUsuariotxt
{
    public string nickname { get; set; }
    public int eliminado { get; set; }
    public nodoUsuariotxt siguiente { get; set; }
    public nodoUsuariotxt(string nick)
    {
        this.nickname = nick;
        this.eliminado = 0;
    }
}
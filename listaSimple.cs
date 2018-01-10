using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for listaSimple
/// </summary>
public class listaSimple
{
    public nodoNivel primero, ultimo;
    public nodoUsuariotxt priUs, ultUs;

    public listaSimple()
    {
        primero = ultimo = null;
        priUs = ultUs = null;
    }

    public void insertar(string nick)
    {
        nodoUsuariotxt n = new nodoUsuariotxt(nick);
        if(priUs == null)
        {
            priUs = n;
            ultUs = n;
        }
        else
        {
            ultUs.siguiente = n;
            ultUs = n;
        }
    }
    public void modificarUsuario(string nick,string newNick)
    {
        nodoUsuariotxt aux = buscarUsuario(nick);
        if(aux != null)
        {
            aux.nickname = newNick;
        }
    }

    public string getUsuarios()
    {
        string s = "";
        if(priUs != null)
        {
            nodoUsuariotxt aux = priUs;
            while(aux != null)
            {
                if(aux.eliminado == 0)
                {
                    s += aux.nickname;
                    if (aux.siguiente != null)
                    {
                        s+=",";
                    }
                }
                aux = aux.siguiente;
            }
        }
        return s;
    }
    public nodoUsuariotxt buscarUsuario(string nick)
    {
        nodoUsuariotxt r = null;
        if(priUs != null)
        {
            r = priUs;
            while(r != null)
            {
                if(r.nickname == nick)
                {
                    break;
                }
                r = r.siguiente;
            }
        }
        return r;
    }

    public void eliminarUsuario(string nick)
    {
        if(priUs != null)
        {
            nodoUsuariotxt aux = buscarUsuario(nick);
            if(aux != null)
            {
                aux.eliminado = 1;//solo vamos a manejar una bandera
            }
        }
    }

    public void vaciarUsuarios()
    {
        priUs = null;
        ultUs = null;
    }

    public void insertar(nodoNivel nodo)
    {
        if(primero == null)
        {
            primero = nodo;
            ultimo = nodo;
        }
        else
        {
            ultimo.siguiente = nodo;
            ultimo = nodo;
        }
    }

    public nodoNivel buscar(string fila, string col)
    {
        nodoNivel r = null;
        if(primero != null)
        {
            r = primero;
            while(r != null)
            {
                if(r.fila == fila && r.columna == col)
                {
                    break;
                }
                r = r.siguiente;
            }
        }
        return r;
    }
    public Boolean buscarFila(string fila)
    {
        bool res = false;
        nodoNivel r = null;
        if (primero != null)
        {
            r = primero;
            while (r != null)
            {
                if (r.fila == fila)
                {
                    res = true;
                    break;
                    
                }
                r = r.siguiente;
            }
        }
        return res;
    }
    public Boolean buscarCol(string col)
    {
        bool res = false;
        nodoNivel r = null;
        if (primero != null)
        {
            r = primero;
            while (r != null)
            {
                if (r.columna == col)
                {
                    res = true;
                    break;

                }
                r = r.siguiente;
            }
        }
        return res;
    }


    public void vaciar()
    {
        primero = null;
        ultimo = null;
    }
    

}
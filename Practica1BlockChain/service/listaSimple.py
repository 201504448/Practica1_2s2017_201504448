class nodoSimple:
    def __init__(self,ip,mascara, carnet, estado):
        self.sig = None
        self.ca = carnet
        self.ip = ip
        self.es = estado
        self.info = str(ip + " " + mascara + " " + carnet + " " + estado)

    def verNodoLista(self)   :
        return self.info

class ListaSimple:
    def __init__(self):
        self.prim = None
        self.ultimo = None

    def vacia(self):
        if self.prim == None:
            return True
        else:
            return False
    def insertar(self, ip, mascara, carnet, estado):
        nuevo = nodoSimple(ip, mascara, carnet, estado)
        if self.vacia() == True:
            self.prim = nuevo
            self.ultimo = nuevo
            print("elemento nuevo: "+self.prim.verNodoLista())
        else:
            self.ultimo.sig = nuevo
            self.ultimo = nuevo
            print("elemento nuevo: " + self.ultimo.verNodoLista())

    def sacar(self):
        if self.vacia() == True:
            print "Lista Vacia"
        else:
            if self.prim.sig != None:
                aux = self.prim.sig
                print ("Elemento eliminado: "+self.prim.verNodoLista())
                self.prim = None
                self.prim = aux
            else:
                 print ("Elemento eliminado: "+self.prim.verNodoLista())
                 self.prim = None
                 self.ultimo = None

    def show(self):
        if self.vacia() == True:
            print ("lista vacia")
        else:
            temporal = self.prim
            while temporal != None:
                print (temporal.verNodoLista())
                temporal = temporal.sig

    def verUltimo(self):
        if self.vacia() == True:
            print ("Lista vacia")
        else:
            print (self.ultimo.verNodoLista())

    def verPrimero(self):
        if self.vacia()== True:
            print ("Lista vacia")
        else:
            print(self.prim.verNodoLista())

    def vaciar(self):

        if self.vacia() == True:
            print ("Lista vacia")
        else:
            while self.prim != None :
                self.sacar()
            self.sacar()

    def buscarCarnet(self, ip):
        # este metodos sera para devolver el carnet del nodo que hizo la peticion de la operacion
        if self.vacia() == True:
            return ("lista vacia")
        else:
            temporal = self.prim
            while temporal.ip != ip and temporal.sig != None:
                temporal = temporal.sig
            if temporal.ip == ip:
                #print "el carnet del que solicito el mensaje es " + temporal.ca
                print temporal.ca
                return temporal.ca
            else:
                return "No se encontro el carnet"
                #print "No se encontro el Nodo"

#lista = ListaSimple()
#lista.insertar("192.168.0.1","255.255.255.0","201504448","Conectado")
#lista.insertar("127.0.0.1","255.255.255.0","201503836","Conectado")
#lista.insertar("129.2.2.1","255.255.255.0","201504567","Desconectado")
#resultado = lista.buscarCarnet("127.0.0.1")
#print "el carnet: "+ resultado+ " le pertenece la ip 127.0.0.1 "
#resultado = lista.buscarCarnet("129.2.2.1")
#print "el carnet: "+ resultado+ " le pertenece la ip 129.2.2.1 "
#resultado = lista.buscarCarnet("192.168.0.1")
#print "el carnet: "+ resultado+ " le pertenece la ip 192.168.0.1 "
#resultado = lista.buscarCarnet("129.2.2.0")
#print "el carnet: "+ resultado+ " le pertenece la ip 129.2.2.0 "
#lista.show()
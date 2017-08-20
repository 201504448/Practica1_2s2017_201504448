class Nodo:
    def __init__(self, dato):
        self.siguiente = None
        self.anterior = None
        self.info = dato

    def verNodo(self):
        return self.info

class ListaDoble:

    def __init__(self):
        self.cabeza = None
        self.cola = None

    def vacia(self):
        if self.cabeza == None:
            return True
        else:
            return False

    def insertarPrimeer(self,dato):
         temporal = Nodo(dato)
         if self.vacia() == True:
             self.cabeza = temporal
             self.cola = temporal
         else:
             temporal.siguiente = self.cabeza
             self.cabeza.anterior = temporal
             self.cabeza = temporal

    def listar(self):
        print("------listar-----")
        temporal = self.cabeza
        while temporal!=None:
            print(temporal.verNodo())
            temporal = temporal.siguiente

    def listarDesdeCola(self):
        print("-------listar desde cola-----")
        temporal = self.cola
        while temporal != None:
            print( temporal.verNodo())
            temporal = temporal.anterior

    def borrarPrimero(self):
        if self.vacia()==False:
            self.cabeza = self.cabeza.siguiente
            self.cabeza.anterior = None

    def borrarUltimo(self):
        if self.cola.anterior == None:
            # quiere decir que solo hay un elemento
            self.cabeza == None
            self.cola == None
        else:
            self.cola = self.cola.anterior
            self.cola.siguiente = None

    def borrarPosicion(self, pos):
        anterior = self.cabeza
        actual = self.cabeza
        x = 0
        if pos > 0:
            while x != pos and actual.siguiente != None:
                anterior = actual
                actual = actual.siguiente
                x+=1
            if x == pos:
                temporal = actual.siguiente
                anterior.siguiente = actual.siguiente
                temporal.anterior = anterior


class pila:
    def __init__(self):
        self.cabeza = None

    def isEmpty(self):
        if self.cabeza == None:
            return True
        else:
            return False 

    def push(self,dato):
        nuevo = Nodo(dato)
        if self.isEmpty() == True:
            self.cabeza = nuevo
            print("elemento nuevo: "+self.cabeza.verNodo())
        else:
            nuevo.siguiente = self.cabeza
            self.cabeza = nuevo
            print("elemento nuevo: "+self.cabeza.verNodo())

    def pop(self):
        if self.isEmpty() == True :
            self.cabeza = None
        else:
            aux = self.cabeza
            self.cabeza = None
            print("Elemento eliminado: "+aux.verNodo())
            return aux.dato    

    def separar(self,dato):
        for letra in dato:
            if letra != "(" and letra != ")" and letra !=  '"' :
                self.push(letra)
    
    def mostrar(self)                :
        print("------Elementos de la pila-----")
        temporal = self.cabeza
        while temporal!=None:
            print(temporal.verNodo())
            temporal = temporal.siguiente

    def vaciar(self):
        if self.isEmpty() == True:
            print ("Pila Vacia")
        else:
            while self.cabeza != None:
                self.pop()
            self.pop()

#listaPila = pila()
#listaPila.separar("2+3")
#listaPila.mostrar()

#listaColita = cola()
#listaColita.encolar("201311118","192.168.0.30","(2+3)")
#listaColita.encolar("201301232","192.168.0.30","(2+3)")
#listaColita.encolar("201584448","192.168.0.40","(2+5)")
#listaColita.mostrar()
#print " la cola es: "
#listaColita.verUltimo()
#print "la cabeza es: "
#listaColita.verPrimero()
#listaColita.sacar()
#print "-------------------------------------"
#listaColita.encolar("201503836","192.168.0.45","(2*10)")
#listaColita.mostrar()
#print " la cola es: "
#listaColita.verUltimo()
#print "la cabeza es: "
#listaColita.verPrimero()
#print "-----------------------"
#listaColita.sacar()
#listaColita.mostrar()
#print "-----------------------"
#listaColita.sacar()
#listaColita.mostrar()
#print "-----------------------"
#listaColita.sacar()
#listaColita.mostrar()
#print "-----------------------"
#listaColita.sacar()
#listaColita.mostrar()


class nodoCola:
    def __init__(self, carne, ip, operacion):
        self.siguiente = None
        self.ca = carne
        self.ip = ip
        self.op = operacion
        self.info = str(carne + " " + ip + " " + operacion)

    def verNodoCola(self):
        return self.info


class cola:
    def __init__(self):
        self.cabeza = None
        self.ultimo = None

    def vacia(self):
        if self.cabeza == None:
            return True
        else:
            return False

    def encolar(self, carnet, ip, operacion):
        nuevo = nodoCola(carnet, ip, operacion)
        if self.vacia() == True:
            self.cabeza = nuevo
            self.ultimo = nuevo
            self.cabeza.siguiente = self.ultimo
            # print("elemento nuevo: "+self.cabeza.verNodo())
        else:
            self.ultimo.siguiente = nuevo
            self.ultimo = nuevo

    def sacar(self):
        if self.vacia() == True:
            print "Cola Vacia"
        else:
            if self.cabeza.siguiente != None:
                aux = self.cabeza.siguiente
                print ("Elemento eliminado: " + self.cabeza.verNodoCola())
                self.cabeza = None
                self.cabeza = aux
            else:
                print ("Elemento eliminado: " + self.cabeza.verNodoCola())
                self.cabeza = None
                self.ultimo = None

    def mostrar(self):
        temporal = self.cabeza
        while temporal != None:
            print(temporal.verNodoCola())
            temporal = temporal.siguiente

    def verUltimo(self):
        if self.vacia() == True:
            print "cola vacia"
        else:
            print (self.ultimo.verNodoCola())

    def verPrimero(self):
        if self.vacia() == True:
            print "cola vacia"
        else:
            print(self.cabeza.verNodoCola())
    def vaciar(self):
        if self.vacia() == True:
            print ("Lista vacia")
        else:
            while self.cabeza != None:
                self.sacar()
            self.sacar()
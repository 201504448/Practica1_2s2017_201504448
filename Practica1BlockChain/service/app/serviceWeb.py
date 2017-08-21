from __future__ import print_function
import sys
from app import app
from flask import request

from listaDobleYPila import pila
from cola import ListaCola
from listaSimple import ListaSimple


@app.route('/conectado')
def function():
	#deberia obtrener la ip y comparar con los archivos JSon para saber si a quien le pertenece el mensaje
	print("estas conectado")
	return "201504448"

@app.route('/metodo2',methods=['POST'])
def h():
    parametroPython = request.form['p']
    return "parametro!! = " + parametroPython

@app.route('/datos',methods = ['POST'])
def datos():
	nombre  = request.form['nom']
	apellido = request.form['ape']
	return 'Sus Datos son ' + nombre + ' ' + apellido

@app.route('/mensaje',methods=['POST'])
def men():
	#tenemos que meter en una cola los mensajes estos mensajes son los que recibo
	ip = request.environ['REMOTE_ADDR']
	print ("la ip que envio el mensaje: "+ip)
	operacion = request.form['inorden']
	#ahora tenemos que acceder a la listasimple para buscar el carnet del usuario que envio la operacion
	try:
		carnet = listaSim.buscarCarnet(ip)
		print ("carnet encontrado: "+ carnet)

	except Exception as e:
		print ("hubo un error al buscar el carnet")
		raise e
	if carnet != "No se encontro el carnet" and carnet!="lista vacia":
		listaCola.encolar("201504448","127.0.0.1", operacion)
		listaPila.separar(operacion)
		listaPila.mostrar()
		return "true"
	else:
		return "false"
@app.route('/respuesta',methods=['POST'])
def res():
	par1 = request.form['inorden']
	par2 = request.form['postorden']
	par3 = request.form['resultado']
	if request.form['inorden'] != ' ' and request.form['postorden'] != ' ' and request.form['resultado'] != ' ':
		print (par1)
		return "true"
	return "false"




@app.route('/cargajson',methods=['POST'])
def cargarJson():
	#ip = request.args.get('ip')
	#tenemos que vaciar la lista simple
	ip = request.form['ip']
	mascara = request.form['mascara']
	carnet = request.form['carnet']
	estado = request.form['estado']
	print (ip + " " + mascara + " " + carnet + " "+ estado)
	#aqui tenemos que insertarlo en la lista simple
	si = False
	try:
		listaSim.insertar(ip, mascara, carnet, estado )
		si = True
	except Exception as e:
		raise e
	if si == True:
		return "Nodo Insertado"
		#return listaSim.mostrar()
	else:
		return "Nodo No insertado"
@app.route('/listaNodos')
def ver():
	#deberia obtrener la ip y comparar con los archivos JSon para saber si a quien le pertenece el mensaje
	listaSim.show()
	print("tendria que haber mostrado los nodos :)")
	return "Se insertaron todos los nodos"

@app.route('/vaciarListaSimple')
def v():
	try:
		listaSim.vaciar()
		listaPila.vaciar()
		listaCola.vaciar()
	except Exception as e:
		raise e
	return "Se vacio la lista"
listaPila = pila()
listaCola = ListaCola()
listaSim = ListaSimple();



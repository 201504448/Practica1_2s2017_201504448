from __future__ import print_function
import sys
from app import app
from flask import request

from nodo import pila, cola, ListaSimple


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
	ip = request.environ['REMOTE_ADDR']
	parametro = request.form['inorden']
	listaPila.separar(parametro)
	listaPila.mostrar()

	return "true"

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
	ip = request.form['ip']
	mascara = request.form['mascara']
	carnet = request.form['carnet']
	estado = request.form['estado']
	print (ip + " " + mascara + " " + carnet + " "+ estado)
	#aqui tenemos que insertarlo en la lista simple
	si = False
	try:
		#listaSim.insertar(ip, mascara, carnet, estado)
		#print (listaSim.verUltimo())
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
	listaSim.mostrar()
	return "Se insertaron todos los nodos"
listaPila = pila()
listaCola = cola()
listaSim = ListaSimple()


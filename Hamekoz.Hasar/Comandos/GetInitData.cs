﻿//
//  GetInitData.cs
//
//  Author:
//       Ezequiel Taranto <ezequiel89@gmail.com>
//
//  Copyright (c) 2014 etaranto
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace Hamekoz.Hasar
{
	public class GetInitData : Comando
	{
		const string cmd = "s";

		public double CUIT { get; set; }

		public string RazonSocial { get; set; }

		public string NroRegistro { get; set; }

		public DateTime FechaDeInicializacion { get; set; }

		public int NroPV { get; set; }

		public DateTime InicioDeActividades { get; set; }

		public string NroIngresosBrutos { get; set; }

		public string ResponsabilidadIVA { get; set; }

		public string Comando ()
		{
			return cmd;
		}

		public GetInitData ()
		{
		}
	}
}


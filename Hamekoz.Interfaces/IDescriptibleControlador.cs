//
//  IDescriptibleControlador.cs
//
//  Author:
//       Claudio Rodrigo Pereyra Diaz <claudiorodrigo@pereyradiaz.com.ar>
//
//  Copyright (c) 2014 Claudio Rodrigo Pereyra Diaz
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
using System.Collections.Generic;

namespace Hamekoz.Interfaces
{
	/// <summary>
	/// Interfaz para controlador de clases aptas para combo
	/// </summary>
	public interface IDescriptibleControlador
	{
		/// <summary>
		/// Gets the descriptibles.
		/// </summary>
		/// <value>The descriptibles.</value>
		IList<IDescriptible> Descriptibles { get; }
	}
}


using OpenCiv1.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenCiv1
{
	public class TerrainMapCellCollection : ICollection<TerrainMapCell>
	{
		private TerrainMap oParent;
		private int width;
		private int height;
		private TerrainMapCell[] aCells;

		internal TerrainMapCellCollection(TerrainMap parent)
		{
			this.oParent = parent;
			this.width = parent.Size.Width;
			this.height = parent.Size.Height;
			this.aCells = new TerrainMapCell[width * height];

			for (int i = 0; i < this.height; i++)
			{
				for (int j = 0; j < this.width; j++)
				{
					TerrainMapCell cell = new TerrainMapCell(j, i);
					this.aCells[(i * this.width) + j] = cell;
					cell.ParentInternal = parent;
				}
			}
		}

		#region AStar (A*) Path finding algorithm
		/// <summary>
		/// Clears the AStar Algorithm related data
		/// </summary>
		internal void ClearAStarData()
		{
			for (int i = 0; i < this.aCells.Length; i++)
			{
				TerrainMapCell cell = this.aCells[i];

				cell.ParentPos = OpenCiv1Game.InvalidPosition;
				cell.GCost = double.MaxValue;
				cell.HCost = double.MaxValue;
				cell.FCost = double.MaxValue;
				cell.IsCellClosed = false;
			}
		}
		#endregion

		#region ICollection<MapCell> Members

		public int Count
		{
			get => this.aCells.Length;
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public void Clear()
		{
			this.aCells = new TerrainMapCell[this.width * this.height];

			for (int i = 0; i < this.height; i++)
			{
				for (int j = 0; j < this.width; j++)
				{
					TerrainMapCell cell = new TerrainMapCell(j, i);
					this.aCells[(i * this.width) + j] = cell;
					cell.ParentInternal = this.oParent;
				}
			}
		}

		public void Add(TerrainMapCell cell)
		{
			if (cell.ParentInternal != null)
			{
				throw new ArgumentException("The provided Cell is already part of a Map collection");
			}
			if (cell.Position.X < 0 || cell.Position.X >= this.width || cell.Position.Y < 0 || cell.Position.Y >= this.height)
			{
				throw new ArgumentOutOfRangeException("The position of the Cell is outside of the Map size range");
			}

			int index = (cell.Y * this.width) + cell.X;

			TerrainMapCell oldCell = this.aCells[index];
			oldCell.ParentInternal = null;

			this.aCells[index] = cell;
			cell.ParentInternal = this.oParent;
		}

		public bool Remove(TerrainMapCell cell)
		{
			return false;
		}

		public bool Contains(TerrainMapCell cell)
		{
			if (cell.ParentInternal == this.oParent)
			{
				return true;
			}

			return false;
		}

		public void CopyTo(TerrainMapCell[] array, int arrayIndex)
		{
			this.aCells.CopyTo(array, arrayIndex);
		}
		#endregion

		#region IEnumerable<MapCell> Members

		public IEnumerator<TerrainMapCell> GetEnumerator()
		{
			return new Enumerator(this);
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.aCells.GetEnumerator();
		}

		#endregion

		public TerrainMapCell this[int index]
		{
			get
			{
				if (index < 0 || index > this.aCells.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}

				return this.aCells[index];
			}
			set
			{
				if (index < 0 || index > this.aCells.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (value.ParentInternal != null)
				{
					throw new ArgumentException("The provided Map Cell is already part of a Map collection");
				}
				if (value.Position.X < 0 || value.Position.X >= this.width || value.Position.Y < 0 || value.Position.Y >= this.height)
				{
					throw new ArgumentOutOfRangeException("The position of the Cell is outside of the Map size range");
				}

				int key = (value.Y * this.width) + value.X;
				if (key != index)
				{
					throw new ArgumentOutOfRangeException("The Cell position and it's index value don't match");
				}

				TerrainMapCell oldCell = this.aCells[index];
				oldCell.ParentInternal = null;

				this.aCells[index] = value;
				this.aCells[index].ParentInternal = this.oParent;
			}
		}

		[XmlIgnore]
		public TerrainMapCell this[GPoint pt]
		{
			get => this[pt.X, pt.Y];
			set => this[pt.X, pt.Y] = value;
		}

		[XmlIgnore]
		public TerrainMapCell this[int x, int y]
		{
			get
			{
				x = this.oParent.WrapXPosition(x);

				if (x < 0 || x >= this.width)
				{
					throw new ArgumentOutOfRangeException("x");
				}
				if (y < 0 || y >= this.height)
				{
					throw new ArgumentOutOfRangeException("y");
				}

				int index = (y * this.width) + x;

				return this.aCells[index];
			}

			set
			{
				x = this.oParent.WrapXPosition(x);

				if (x < 0 || x >= this.width || value.X != x)
				{
					throw new ArgumentOutOfRangeException("x");
				}
				if (y < 0 || y >= this.height || value.Y != y)
				{
					throw new ArgumentOutOfRangeException("y");
				}

				int index = (value.Y * this.width) + value.X;

				TerrainMapCell oldCell = this.aCells[index];
				oldCell.ParentInternal = null;

				this.aCells[index] = value;
				this.aCells[index].ParentInternal = this.oParent;
			}
		}

		public struct Enumerator : IEnumerator<TerrainMapCell>
		{
			private TerrainMapCellCollection oParent;
			private int iCurrentIndex;
			private TerrainMapCell oCurrentItem;

			internal Enumerator(TerrainMapCellCollection parent)
			{
				this.oParent = parent;
				this.iCurrentIndex = -1;
				this.oCurrentItem = TerrainMapCell.Empty;
			}

			#region IEnumerator<MapCell> Members
			public TerrainMapCell Current
			{
				get
				{
					return this.oCurrentItem;
				}
			}
			#endregion

			#region IDisposable Members
			public void Dispose() { }
			#endregion

			#region IEnumerator Members
			object System.Collections.IEnumerator.Current
			{
				get
				{
					return this.oCurrentItem;
				}
			}

			public bool MoveNext()
			{
				//Avoids going beyond the end of the collection. 
				if (++this.iCurrentIndex >= this.oParent.Count)
				{
					this.oCurrentItem = TerrainMapCell.Empty;
					return false;
				}
				else
				{
					// Set current box to next item in collection.
					this.oCurrentItem = this.oParent[this.iCurrentIndex];
				}
				return true;
			}

			public void Reset()
			{
				this.iCurrentIndex = -1;
				this.oCurrentItem = TerrainMapCell.Empty;
			}
			#endregion
		}
	}
}

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
	public class MapCellCollection : ICollection<MapCell>
	{
		private Map oParent;
		private int width;
		private int height;
		private MapCell[] aCells;

		internal MapCellCollection(Map parent)
		{
			this.oParent = parent;
			this.width = parent.Size.Width;
			this.height = parent.Size.Height;
			this.aCells = new MapCell[width * height];

			for (int i = 0; i < this.height; i++)
			{
				for (int j = 0; j < this.width; j++)
				{
					MapCell cell = new MapCell(j, i);
					this.aCells[(i * this.width) + j] = cell;
					cell.ParentInternal = parent;
				}
			}
		}

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
			this.aCells = new MapCell[this.width * this.height];

			for (int i = 0; i < this.height; i++)
			{
				for (int j = 0; j < this.width; j++)
				{
					MapCell cell = new MapCell(j, i);
					this.aCells[(i * this.width) + j] = cell;
					cell.ParentInternal = this.oParent;
				}
			}
		}

		public void Add(MapCell cell)
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

			MapCell oldCell = this.aCells[index];
			oldCell.ParentInternal = null;

			this.aCells[index] = cell;
			cell.ParentInternal = this.oParent;
		}

		public bool Remove(MapCell cell)
		{
			return false;
		}

		public bool Contains(MapCell cell)
		{
			if (cell.ParentInternal == this.oParent)
			{
				return true;
			}

			return false;
		}

		public void CopyTo(MapCell[] array, int arrayIndex)
		{
			this.aCells.CopyTo(array, arrayIndex);
		}
		#endregion

		#region IEnumerable<MapCell> Members

		public IEnumerator<MapCell> GetEnumerator()
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

		public MapCell this[int index]
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

				MapCell oldCell = this.aCells[index];
				oldCell.ParentInternal = null;

				this.aCells[index] = value;
				this.aCells[index].ParentInternal = this.oParent;
			}
		}

		[XmlIgnore]
		public MapCell this[int x, int y]
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

				MapCell oldCell = this.aCells[index];
				oldCell.ParentInternal = null;

				this.aCells[index] = value;
				this.aCells[index].ParentInternal = this.oParent;
			}
		}

		public struct Enumerator : IEnumerator<MapCell>
		{
			private MapCellCollection oParent;
			private int iCurrentIndex;
			private MapCell oCurrentItem;

			internal Enumerator(MapCellCollection parent)
			{
				this.oParent = parent;
				this.iCurrentIndex = -1;
				this.oCurrentItem = MapCell.Empty;
			}

			#region IEnumerator<MapCell> Members
			public MapCell Current
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
					this.oCurrentItem = MapCell.Empty;
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
				this.oCurrentItem = MapCell.Empty;
			}
			#endregion
		}
	}
}

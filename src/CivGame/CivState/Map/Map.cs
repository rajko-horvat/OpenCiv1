using IRB.Collections.Generic;
using OpenCiv1.GPU;
using System;
using System.Xml.Serialization;

namespace OpenCiv1
{
	[Serializable]
	public class Map : IList<MapCell>
	{
		private CivState? oParent = null;

		private static GSize oMinSize = new GSize(10, 10);

		private GSize oSize;
		private int iMedian;
		private List<MapCell> aCells = new List<MapCell>();
		private BDictionary<int, int> oDictCells = new BDictionary<int, int>();

		public Map()
		{
			this.oSize = new GSize(80, 50);
			this.iMedian = this.oSize.Width / 2;
		}

		public Map(int width, int height) : this(new GSize(width, height))
		{ }

		public Map(GSize size)
		{
			// sanity check
			if (size.Width < 0 || size.Width < oMinSize.Width)
			{
				throw new ArgumentOutOfRangeException("Width");
			}
			if (size.Height < 0 || size.Height < oMinSize.Height)
			{
				throw new ArgumentOutOfRangeException("Height");
			}

			this.oSize = size;
			this.iMedian = this.oSize.Width / 2;
		}

		public static Map FromPIC(string path)
		{
			byte[] palette;
			GBitmap? bitmap = GBitmap.FromPICFile(path, out palette);
			Map map = new Map(80, 50);

			if (bitmap == null)
			{
				throw new Exception("Can't load bitmap from file");
			}

			for (int j = 0; j < 50; j++)
			{
				for (int i = 0; i < 80; i++)
				{
					MapCell cell = new MapCell(i, j);

					cell.Layer1 = bitmap.GetPixel(i, j);
					cell.Layer2 = bitmap.GetPixel(i + 80, j);

					cell.Layer3 = bitmap.GetPixel(i, j + 50);
					cell.Layer4 = bitmap.GetPixel(i + 80, j + 50);

					cell.Layer5 = bitmap.GetPixel(i, j + 100);
					cell.Layer6 = bitmap.GetPixel(i + 80, j + 100);

					cell.Layer7 = bitmap.GetPixel(i, j + 150);
					cell.Layer8 = bitmap.GetPixel(i + 80, j + 150);

					cell.Layer9 = bitmap.GetPixel(i + 160, j);
					cell.Layer10 = bitmap.GetPixel(i + 240, j);

					map.Add(cell);
				}
			}

			return map;
		}

		public GBitmap ToBitmap()
		{
			int width = this.oSize.Width;
			int height = this.oSize.Height;
			GBitmap bitmap = new GBitmap(width * 4, height * 4);


			for (int j = 0; j < height; j++)
			{
				for (int i = 0; i < width; i++)
				{
					MapCell? cell = this[i, j];

					if (cell != null)
					{
						bitmap.SetPixel(i, j, (byte)(cell.Layer1 & 0xff));
						bitmap.SetPixel(i + width, j, (byte)(cell.Layer2 & 0xff));

						bitmap.SetPixel(i, j + height, (byte)(cell.Layer3 & 0xff));
						bitmap.SetPixel(i + width, j + height, (byte)(cell.Layer4 & 0xff));

						bitmap.SetPixel(i, j + height * 2, (byte)(cell.Layer5 & 0xff));
						bitmap.SetPixel(i + width, j + height * 2, (byte)(cell.Layer6 & 0xff));

						bitmap.SetPixel(i, j + height * 3, (byte)(cell.Layer7 & 0xff));
						bitmap.SetPixel(i + width, j + height * 3, (byte)(cell.Layer8 & 0xff));

						bitmap.SetPixel(i + width * 2, j, (byte)(cell.Layer9 & 0xff));
						bitmap.SetPixel(i + width * 3, j, (byte)(cell.Layer10 & 0xff));
					}
				}
			}

			return bitmap;
		}

		[XmlIgnore]
		public CivState? Parent
		{
			get => this.oParent;
			set => this.oParent = value;
		}

		public GSize Size
		{
			get => this.oSize;
			set
			{
				if (this.oSize != value)
				{
					// sanity check
					if (value.Width < 0 || value.Width < oMinSize.Width)
					{
						throw new ArgumentOutOfRangeException("Size.Width");
					}
					if (value.Height < 0 || value.Height < oMinSize.Height)
					{
						throw new ArgumentOutOfRangeException("Size.Height");
					}
					if (this.aCells.Count > 0)
					{
						throw new InvalidOperationException("The size of the map can't be changed after the map has been populated");
					}

					this.oSize = value;
					this.iMedian = this.oSize.Width / 2;
				}
			}
		}

		#region IList<MapCell> Members

		public int Count
		{
			get => this.aCells.Count;
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public void Add(MapCell cell)
		{
			if (cell.ParentInternal != null)
			{
				throw new ArgumentException("The provided Cell is already part of a Map collection");
			}
			if (cell.Position.X < 0 || cell.Position.X >= this.oSize.Width || cell.Position.Y < 0 || cell.Position.Y >= this.oSize.Height)
			{
				throw new ArgumentOutOfRangeException("The position of the Cell is out of the Map size range");
			}

			int key = (cell.Position.Y * this.oSize.Width) + cell.Position.X;

			if (this.oDictCells.ContainsKey(key))
			{
				throw new InvalidOperationException("The Map collection already contains the Cell at the same coordinates");
			}
			else
			{
				int index = this.aCells.Count;

				this.aCells.Add(cell);
				cell.ParentInternal = this;

				this.oDictCells.Add(key, index);
			}
		}

		public void Clear()
		{
			this.aCells.Clear();
			this.oDictCells.Clear();
		}

		public bool Contains(MapCell cell)
		{
			if (cell.ParentInternal == this)
			{
				return this.oDictCells.ContainsKey((cell.Position.Y * this.oSize.Width) + cell.Position.X);
			}

			return false;
		}

		public void CopyTo(MapCell[] array, int arrayIndex)
		{
			this.aCells.CopyTo(array, arrayIndex);
		}

		public int IndexOf(MapCell cell)
		{
			if (cell.ParentInternal == this)
			{
				int key = (cell.Position.Y * this.oSize.Width) + cell.Position.X;

				if (this.oDictCells.ContainsKey(key))
				{
					return this.oDictCells.GetValueByKey(key);
				}
			}

			return -1;
		}

		public void Insert(int index, MapCell cell)
		{
			if (cell.ParentInternal != null)
			{
				throw new ArgumentException("The provided Cell is already part of a Map collection");
			}
			if (cell.Position.X < 0 || cell.Position.X >= this.oSize.Width || cell.Position.Y < 0 || cell.Position.Y >= this.oSize.Height)
			{
				throw new ArgumentOutOfRangeException("The position of the Cell is out of the Map size range");
			}

			int key = (cell.Position.Y * this.oSize.Width) + cell.Position.X;

			if (this.oDictCells.ContainsKey(key))
			{
				throw new InvalidOperationException("The Map collection already contains the Cell at the same coordinates");
			}
			else
			{
				for (int i = 0; i < this.oDictCells.Count; i++)
				{
					BKeyValuePair<int, int> pair = this.oDictCells[i];

					if (pair.Value >= index)
					{
						this.oDictCells[i] = new BKeyValuePair<int, int>(pair.Key, pair.Value + 1);
					}
				}

				this.aCells.Insert(index, cell);
				cell.ParentInternal = this;

				this.oDictCells.Add(key, index);
			}
		}

		public bool Remove(MapCell cell)
		{
			if (cell.ParentInternal == this)
			{
				int key = (cell.Position.Y * this.oSize.Width) + cell.Position.X;

				if (this.oDictCells.ContainsKey(key))
				{
					int index = this.oDictCells.GetValueByKey(key);

					this.aCells.RemoveAt(index);
					this.oDictCells.RemoveByKey(key);

					for (int i = 0; i < this.oDictCells.Count; i++)
					{
						BKeyValuePair<int, int> pair = this.oDictCells[i];

						if (pair.Value > index)
						{
							this.oDictCells[i] = new BKeyValuePair<int, int>(pair.Key, pair.Value - 1);
						}
					}

					return true;
				}
			}

			return false;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index > this.aCells.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}

			MapCell cell = this.aCells[index];
			int key = (cell.Position.Y * this.oSize.Width) + cell.Position.X;

			this.aCells.RemoveAt(index);
			this.oDictCells.RemoveByKey(key);

			for (int i = 0; i < this.oDictCells.Count; i++)
			{
				BKeyValuePair<int, int> pair = this.oDictCells[i];

				if (pair.Value > index)
				{
					this.oDictCells[i] = new BKeyValuePair<int, int>(pair.Key, pair.Value - 1);
				}
			}
		}

		#endregion

		#region IEnumerable<MapCell> Members

		public IEnumerator<MapCell> GetEnumerator()
		{
			return this.aCells.GetEnumerator();
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
				if (index < 0 || index > this.aCells.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}

				return this.aCells[index];
			}
			set
			{
				if (index < 0 || index > this.aCells.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (value.ParentInternal != null)
				{
					throw new ArgumentException("The provided Map Cell is already part of a Map collection");
				}
				if (value.Position.X < 0 || value.Position.X >= this.oSize.Width || value.Position.Y < 0 || value.Position.Y >= this.oSize.Height)
				{
					throw new ArgumentOutOfRangeException("The position of the Cell is out of the Map size range");
				}

				int key = (value.Position.Y * this.oSize.Width) + value.Position.X;
				MapCell oldCell = this.aCells[index];

				oldCell.ParentInternal = null;

				this.aCells[index] = value;
				this.aCells[index].ParentInternal = this;

				if (this.oDictCells.ContainsKey(key))
				{
					this.oDictCells.SetValueByKey(key, index);
				}
				else
				{
					this.oDictCells.Add(key, index);
				}
			}
		}

		[XmlIgnore]
		public MapCell? this[int x, int y]
		{
			get
			{
				if (x < 0 || x >= this.oSize.Width)
				{
					throw new ArgumentOutOfRangeException("x");
				}
				if (y < 0 || y >= this.oSize.Height)
				{
					throw new ArgumentOutOfRangeException("y");
				}

				int key = (y * this.oSize.Width) + x;

				if (this.oDictCells.ContainsKey(key))
				{
					return this.aCells[this.oDictCells.GetValueByKey(key)];
				}

				return null;
			}
			set
			{
				if (x < 0 || x >= this.oSize.Width)
				{
					throw new ArgumentOutOfRangeException("x");
				}
				if (y < 0 || y >= this.oSize.Height)
				{
					throw new ArgumentOutOfRangeException("y");
				}

				int key = (y * this.oSize.Width) + x;

				if (value != null)
				{
					if (this.oDictCells.ContainsKey(key))
					{
						int index = this.oDictCells.GetValueByKey(key);
						MapCell oldCell = this.aCells[index];

						oldCell.ParentInternal = null;

						this.aCells[index] = value;
						this.aCells[index].ParentInternal = this;
					}
					else
					{
						int index = this.aCells.Count;

						this.aCells.Add(value);
						this.aCells[index].ParentInternal = this;
						this.oDictCells.Add(key, index);
					}
				}
				else
				{
					if (this.oDictCells.ContainsKey(key))
					{
						int index = this.oDictCells.GetValueByKey(key);
						MapCell oldCell = this.aCells[index];

						this.oDictCells.RemoveByKey(key);
						this.aCells.RemoveAt(index);
						oldCell.ParentInternal = null;

						for (int i = 0; i < this.oDictCells.Count; i++)
						{
							BKeyValuePair<int, int> pair = this.oDictCells[i];

							if (pair.Value > index)
							{
								this.oDictCells[i] = new BKeyValuePair<int, int>(pair.Key, pair.Value - 1);
							}
						}
					}
				}
			}
		}
	}
}

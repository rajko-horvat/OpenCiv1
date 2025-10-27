using System.Xml.Serialization;

namespace OpenCiv1.API
{
	[Serializable]
	public class RandomMT19937State
	{
		private uint[] matrix; // Array for the state vector
		private int matrixIndex; // matrixIndex == matrixLength + 1 means matrix[matrixLength] is not initialized

		public RandomMT19937State()
		{
			this.matrix = new uint[1];
			this.matrixIndex = 1;
		}

		internal RandomMT19937State(int matrixLength)
		{
			this.matrix = new uint[matrixLength];
			this.matrixIndex = matrixLength + 1;
		}

		[XmlArray]
		public uint[] Matrix { get => matrix; set => matrix = value; }

		public int MatrixIndex { get => matrixIndex; set => matrixIndex = value; }
	}
}

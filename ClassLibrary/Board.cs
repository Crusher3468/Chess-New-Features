/***************************************************************
 * File: Board.cs
 * Created By: Justin Grindal		Date: 27 June, 2013
 * Description: The main chess board. Board contain the chess cell
 * which will contain the chess pieces. Board also contains the methods
 * to get and set the user moves.
 ***************************************************************/

using System;
using System.Collections;
using System.Xml;

namespace ChessLibrary
{
	/// <summary>
	/// he main chess board. Board contain the chess cell
	/// which will contain the chess pieces. Board also contains the methods
	/// to get and set the user moves.
	/// </summary>
    [Serializable]
	public class Board
	{
		// My Code
        public static bool nine;

		public static bool Nine
		{
			get { return nine; }
			set { nine = value; }
		}

		// Not My Code
        private Side m_WhiteSide, m_BlackSide;	// Chess board site object 
		private Cells m_cells;	// collection of cells in the board

		public Board()
		{
            m_WhiteSide = new Side(Side.SideType.White);	// Makde white side
            m_BlackSide = new Side(Side.SideType.Black);	// Makde white side

			m_cells = new Cells();					// Initialize the chess cells collection
		}

		// Initialize the chess board and place piece on thier initial positions
		public void Init()
		{
			m_cells.Clear();        // Remove any existing chess cells

			// Build the 64 chess board cells
			for (int row = 1; row <= 8; row++)
				for (int col = 1; col <= 8; col++)
				{
					m_cells.Add(new Cell(row, col));    // Initialize and add the new chess cell
				}

			//My Code
			if (nine == true)
			{
				string[,] position = {
				{"a", "none"},
				{"b", "none"},
				{"c", "none"},
				{"d", "none"},
				{"e", "none",},
				{"f", "none"},
				{"g", "none"},
				{"h", "none"},
			};

				Random rnd = new Random();

				string i = "none";
				string black, white;
				int rook1 = 0, rook2 = 0;

				// Rook1
				int j = rnd.Next(0, 7);
				if (position[j, 1] == "none")
				{
					i = position[j, 0];
					position[j, 1] = "rook";
					rook1 = j;
					black = i + "1";
					white = i + "8";
					m_cells[black].piece = new Piece(Piece.PieceType.Rook, m_BlackSide);
					m_cells[white].piece = new Piece(Piece.PieceType.Rook, m_WhiteSide);
				}


				//Rook 2
				int r = 0;
				do
				{
					j = rnd.Next(0, 7);
					if (position[j, 1] == "none")
					{
						if (j == 0)
						{
							if (position[j + 1, 1] == "none")
							{
								i = position[j, 0];
								position[j, 1] = "rook";
								rook2 = j;
								black = i + "1";
								white = i + "8";
								m_cells[black].piece = new Piece(Piece.PieceType.Rook, m_BlackSide);
								m_cells[white].piece = new Piece(Piece.PieceType.Rook, m_WhiteSide);
								r = 1;
							}
						}

						else if (j == 7)
						{
							if (position[j - 1, 1] == "none")
							{
								i = position[j, 0];
								position[j, 1] = "rook";
								rook2 = j;
								black = i + "1";
								white = i + "8";
								m_cells[black].piece = new Piece(Piece.PieceType.Rook, m_BlackSide);
								m_cells[white].piece = new Piece(Piece.PieceType.Rook, m_WhiteSide);
								r = 1;
							}
						}

						else if ((position[(j - 1), 1] == "none") && (position[(j + 1), 1] == "none"))
						{
							i = position[j, 0];
							position[j, 1] = "rook";
							rook2 = j;
							black = i + "1";
							white = i + "8";
							m_cells[black].piece = new Piece(Piece.PieceType.Rook, m_BlackSide);
							m_cells[white].piece = new Piece(Piece.PieceType.Rook, m_WhiteSide);

							r = 1;
						}
					}
				} while (r == 0);

				// King
				int k = 0;
				do
				{
					if (rook1 > rook2) j = rnd.Next(rook2 + 1, rook1 - 1);

					if (rook1 < rook2) j = rnd.Next(rook1 + 1, rook2 - 1);

					if (position[j, 1] == "none")
					{
						i = position[j, 0];
						position[j, 1] = "king";
						black = i + "1";
						white = i + "8";
						m_cells[black].piece = new Piece(Piece.PieceType.King, m_BlackSide);
						m_cells[white].piece = new Piece(Piece.PieceType.King, m_WhiteSide);
						k = 1;
					}

				} while (k == 0);

				// Bishop 1
				int b = 0;
				do
				{
					j = rnd.Next(0, 7); ;

					if (j % 2 == 0)
					{
						if (position[j, 1] == "none")
						{
							i = position[j, 0];
							position[j, 1] = "bishop";
							black = i + "1";
							white = i + "8";
							m_cells[black].piece = new Piece(Piece.PieceType.Bishop, m_BlackSide);
							m_cells[white].piece = new Piece(Piece.PieceType.Bishop, m_WhiteSide);
							b = 1;
						}
					}
				} while (b == 0);

				b = 0;
				do
				{
					j = rnd.Next(0, 7); ;

					if (j % 2 == 1)
					{
						if (position[j, 1] == "none")
						{
							i = position[j, 0];
							position[j, 1] = "bishop";
							black = i + "1";
							white = i + "8";
							m_cells[black].piece = new Piece(Piece.PieceType.Bishop, m_BlackSide);
							m_cells[white].piece = new Piece(Piece.PieceType.Bishop, m_WhiteSide);
							b = 1;
						}
					}
				} while (b == 0);

				//Rooks
				for (int x = 0; x < 2; x++)
				{
					k = 0;
					do
					{
						j = rnd.Next(0, 7); ;
						if (position[j, 1] == "none")
						{
							i = position[j, 0];
							position[j, 1] = "knight";
							black = i + "1";
							white = i + "8";
							m_cells[black].piece = new Piece(Piece.PieceType.Knight, m_BlackSide);
							m_cells[white].piece = new Piece(Piece.PieceType.Knight, m_WhiteSide);
							k = 1;
						}
					} while (k == 0);
				}

				for (int y = 0; y < 8; y++)
				{
					if (position[y, 1] == "none")
					{
						i = position[y, 0];
						position[y, 1] = "Queen";
						black = i + "1";
						white = i + "8";
						m_cells[black].piece = new Piece(Piece.PieceType.Queen, m_BlackSide);
						m_cells[white].piece = new Piece(Piece.PieceType.Queen, m_WhiteSide);
						k = 1;
					}
				}

				for (int col = 1; col <= 8; col++)
					m_cells[2, col].piece = new Piece(Piece.PieceType.Pawn, m_BlackSide);
				for (int col = 1; col <= 8; col++)
					m_cells[7, col].piece = new Piece(Piece.PieceType.Pawn, m_WhiteSide);
			}
			else
			{

				// Not My Code
				// Now setup the board for black side
				m_cells["a1"].piece = new Piece(Piece.PieceType.Rook, m_BlackSide);
				m_cells["h1"].piece = new Piece(Piece.PieceType.Rook, m_BlackSide);
				m_cells["b1"].piece = new Piece(Piece.PieceType.Knight, m_BlackSide);
				m_cells["g1"].piece = new Piece(Piece.PieceType.Knight, m_BlackSide);
				m_cells["c1"].piece = new Piece(Piece.PieceType.Bishop, m_BlackSide);
				m_cells["f1"].piece = new Piece(Piece.PieceType.Bishop, m_BlackSide);
				m_cells["e1"].piece = new Piece(Piece.PieceType.King, m_BlackSide);
				m_cells["d1"].piece = new Piece(Piece.PieceType.Queen, m_BlackSide);

				for (int col = 1; col <= 8; col++)
					m_cells[2, col].piece = new Piece(Piece.PieceType.Pawn, m_BlackSide);


				// Now setup the board for white side

				m_cells["a8"].piece = new Piece(Piece.PieceType.Rook, m_WhiteSide);
				m_cells["h8"].piece = new Piece(Piece.PieceType.Rook, m_WhiteSide);
				m_cells["b8"].piece = new Piece(Piece.PieceType.Knight, m_WhiteSide);
				m_cells["g8"].piece = new Piece(Piece.PieceType.Knight, m_WhiteSide);
				m_cells["c8"].piece = new Piece(Piece.PieceType.Bishop, m_WhiteSide);
				m_cells["f8"].piece = new Piece(Piece.PieceType.Bishop, m_WhiteSide);
				m_cells["e8"].piece = new Piece(Piece.PieceType.King, m_WhiteSide);
				m_cells["d8"].piece = new Piece(Piece.PieceType.Queen, m_WhiteSide);

				for (int col = 1; col <= 8; col++)
					m_cells[7, col].piece = new Piece(Piece.PieceType.Pawn, m_WhiteSide);
			}
		}

		// get the new item by rew and column
		public Cell this[int row, int col]
		{
			get
			{
				return m_cells[row, col];
			}
		}

		// get the new item by string location
		public Cell this[string strloc]
		{
			get
			{
				return m_cells[strloc];	
			}
		}

		// get the chess cell by given cell
		public Cell this[Cell cellobj]
		{
			get
			{
				return m_cells[cellobj.ToString()];	
			}
		}

        /// <summary>
        /// Serialize the Game object as XML String
        /// </summary>
        /// <returns>XML containing the Game object state XML</returns>
        public XmlNode XmlSerialize(XmlDocument xmlDoc)
        {
            XmlElement xmlBoard = xmlDoc.CreateElement("Board");

            // Append game state attributes
            xmlBoard.AppendChild(m_WhiteSide.XmlSerialize(xmlDoc));
            xmlBoard.AppendChild(m_BlackSide.XmlSerialize(xmlDoc));

            xmlBoard.AppendChild(m_cells.XmlSerialize(xmlDoc));

            // Return this as String
            return xmlBoard;
        }

        /// <summary>
        /// DeSerialize the Board object from XML String
        /// </summary>
        /// <returns>XML containing the Board object state XML</returns>
        public void XmlDeserialize(XmlNode xmlBoard)
        {
            // Deserialize the Sides XML
            XmlNode side = XMLHelper.GetFirstNodeByName(xmlBoard, "Side");

            // Deserialize the XML nodes
            m_WhiteSide.XmlDeserialize(side);
            m_BlackSide.XmlDeserialize(side.NextSibling);

            // Deserialize the Cells
            XmlNode xmlCells = XMLHelper.GetFirstNodeByName(xmlBoard, "Cells");
            m_cells.XmlDeserialize(xmlCells);
        }

		// get all the cell locations on the chess board
		public ArrayList GetAllCells()
		{
			ArrayList CellNames = new ArrayList();

			// Loop all the squars and store them in Array List
			for (int row=1; row<=8; row++)
				for (int col=1; col<=8; col++)
				{
					CellNames.Add(this[row,col].ToString()); // append the cell name to list
				}

			return CellNames;
		}

		// get all the cell containg pieces of given side
        public ArrayList GetSideCell(Side.SideType PlayerSide)
		{
			ArrayList CellNames = new ArrayList();

			// Loop all the squars and store them in Array List
			for (int row=1; row<=8; row++)
				for (int col=1; col<=8; col++)
				{
					// check and add the current type cell
					if (this[row,col].piece!=null && !this[row,col].IsEmpty() && this[row,col].piece.Side.type == PlayerSide)
						CellNames.Add(this[row,col].ToString()); // append the cell name to list
				}

			return CellNames;
		}

		// Returns the cell on the top of the given cell
		public Cell TopCell(Cell cell)
		{
			return this[cell.row-1, cell.col];
		}

		// Returns the cell on the left of the given cell
		public Cell LeftCell(Cell cell)
		{
			return this[cell.row, cell.col-1];
		}

		// Returns the cell on the right of the given cell
		public Cell RightCell(Cell cell)
		{
			return this[cell.row, cell.col+1];
		}

		// Returns the cell on the bottom of the given cell
		public Cell BottomCell(Cell cell)
		{
			return this[cell.row+1, cell.col];
		}

		// Returns the cell on the top-left of the current cell
		public Cell TopLeftCell(Cell cell)
		{
			return this[cell.row-1, cell.col-1];
		}

		// Returns the cell on the top-right of the current cell
		public Cell TopRightCell(Cell cell)
		{
			return this[cell.row-1, cell.col+1];
		}

		// Returns the cell on the bottom-left of the current cell
		public Cell BottomLeftCell(Cell cell)
		{
			return this[cell.row+1, cell.col-1];
		}

		// Returns the cell on the bottom-right of the current cell
		public Cell BottomRightCell(Cell cell)
		{
			return this[cell.row+1, cell.col+1];
		}
	}
}

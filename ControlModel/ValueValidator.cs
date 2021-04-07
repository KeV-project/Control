using System;
using System.IO;

namespace ControlModel
{
	public static class ValueValidator
	{
		private static bool IsFileExe(FileInfo filePath)
		{
			const string extension = ".exe";
			return filePath.Extension == extension;
		}

		private static bool IsFileDll(FileInfo filePath)
		{
			const string extension = ".dll";
			return filePath.Extension == extension;
		}

		public static void AssertCorrectFile(FileInfo filePath)
		{
			const string correctExtension = "Допустимые расширения: " 
				+ "\".exe\", \".dll\".";
			if (!(IsFileExe(filePath) || IsFileDll(filePath)))
			{
				throw new ArgumentException("Файл с именем \"" 
					+ filePath.Name + "\" имеет недопустимое расширение. " 
					+ correctExtension);
			}
		}
	}
}

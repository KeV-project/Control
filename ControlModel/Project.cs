using System.Collections.Generic;

namespace ControlModel
{
    /// <summary>
    /// Класс <see cref="Prpject"/> хранит пользовательские
    /// данные приложения
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Хранит список объектов класса <see cref="FileData"/>
        /// </summary>
        private List<FileData> _filesData;

        /// <summary>
        /// Возвращает объект класса <see cref="FileData"/>
        /// по указанному индексу
        /// </summary>
        /// <param name="index">Индекс объекта</param>
        /// <returns>Возвращает объект класса <see cref="FileData"/>
        /// по указанному индексу</returns>
        public FileData this[int index] => _filesData[index];

        /// <summary>
        /// Инициализирует объект класса значениями по умолчанию
        /// </summary>
        public Project()
        {
            _filesData = new List<FileData>();
        }

        /// <summary>
        /// Добавляет объект класса <see cref="FileData"/>
        /// в список проекта
        /// </summary>
        /// <param name="fileData">Добавляемый объект</param>
        public void AddFileData(FileData fileData)
        {
            _filesData.Add(fileData);
        }

        /// <summary>
        /// Удаляет объект класса <see cref="FileData"/>
        /// из списка проекта
        /// </summary>
        /// <param name="fileData">Удаляемый объект</param>
        public void RemoveFileData(FileData fileData)
        {
            _filesData.Remove(fileData);
        }
    }
}

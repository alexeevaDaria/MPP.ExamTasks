# MPP.ExamTasks
Задача 1.

Реализовать консольную программу на языке C#, которая: 
- принимает в параметре командной строки путь к исходному и целевому каталогам на диске;
- выполняет параллельное копирование всех файлов из исходного  каталога в целевой каталог;
- выполняет операции копирования параллельно с помощью пула потоков;
- дожидается окончания всех операций копирования и выводит в консоль информацию о количестве скопированных файлов.

 
Задача 2.

Создать класс на языке C#, который: 
- называется TaskQueue и реализует логику пула потоков;
- создает указанное количество потоков пула в конструкторе;
- содержит очередь задач в виде делегатов без параметров:
delegate void TaskDelegate();
- обеспечивает постановку в очередь и последующее выполнение делегатов с помощью метода 
void EnqueueTask(TaskDelegate task);

 
Задача 3.

Создать класс на языке C#, который: 
- называется OSHandle и обеспечивает автоматическое или принудительное освобождение заданного дескриптора операционной системы;
- содержит свойство Handle, позволяющее установить и получить дескриптор операционной системы; 
- реализует метод Finalize для автоматического освобождения дескриптора;
- реализует интерфейс IDisposable для принудительного освобождения дескриптора; 

 
Задача 4.

Создать класс на языке C#, который: 
- называется LogFile и обеспечивает добавление указанных строк в текстовый журнал работы программы;
- открывает файл в конструкторе;
- реализует интерфейс IDisposable и позволяет принудительно закрыть файл с помощью метода Dispose;
- реализует метод Write(string str), записывающий указанную строку в формате <год-месяц-день><пробел><часы:минуты:секунды.миллисекунды><пробел><номер программного потока, вызвавшего метод><пробел><str>

 
Задача 5.

Создать класс на языке C#, который: 
- называется Mutex и реализует двоичный семафор с помощью атомарной операции Interlocked.CompareExchange. 
- обеспечивает блокировку и разблокировку двоичного семафора с помощью public-методов Lock и Unlock.
 
Задача 6.

Реализовать консольную программу на языке C#, которая: 
- принимает в параметре командной строки путь к сборке .NET (EXE- или DLL-файлу);
- загружает указанную сборку в память;
- выводит на экран полные имена всех public-типов данных этой сборки, упорядоченные по пространству имен (namespace) и по имени.
 
Задача 8.

Создать класс на языке C#, который: 
Создать класс LogBuffer, который:
- представляет собой журнал строковых сообщений;
- предоставляет метод public void Add(string item);
- буферизирует добавляемые одиночные сообщения и записывает их пачками в конец текстового файла на диске;
- периодически выполняет запись накопленных сообщений, когда их количество достигает заданного предела;
- периодически выполняет запись накопленных сообщений по истечение заданного интервала времени (вне зависимости от наполнения буфера);
- выполняет запись накопленных сообщений асинхронно с добавлением сообщений в буфер;

 
Задача 9.

Создать на языке C# статический метод класса Parallel.WaitAll, который: 
- принимает в параметрах массив делегатов;
- выполняет все указанные делегаты параллельно с помощью пула потоков;
- дожидается окончания выполнения всех делегатов.
Реализовать простейший пример использования метода Parallel.WaitAll.

 
Задача 10.

Создать на языке C# пользовательский атрибут с именем ExportClass, применимый только к классам, и реализовать консольную программу, которая: 
- принимает в параметре командной строки путь к сборке .NET (EXE- или DLL-файлу);
- загружает указанную сборку в память;
- выводит на экран полные имена всех public-типов данных этой сборки, помеченные атрибутом ExportClass.

 
Задача 11.

Создать на языке C# статический метод Where статического класса EnumeratorExtension, который: 
- имеет вид:
public static IEnumerable<T> Where(this IEnumerable<T> source, Func<T, bool> predicate);
- реализует шаблон Enumerator и возвращает только те элементы переданного виртуального списка source, для которых делегат predicate возвращает значение true.
Реализовать простейший пример использования метода EnumeratorExtension.Where.
 
 
Задача 12.

Создать на языке C# обобщенный (generic-) класс DynamicList<T>, который:
- реализует динамический массив с помощью обычного массива T[];
- имеет свойство Count, показывающее количество элементов; 
- имеет свойство Items для доступа к элементам по индексу; 
- имеет методы Add, Remove, RemoveAt, Clear для соответственно добавления, удаления, удаления по индексу и удаления всех элементов;
- реализует интерфейс IEnumerable<T>.
Реализовать простейший пример использования класса DynamicList<T> на языке C#.

Module ModuleStructures
    Public FileName As String
    Public RecordsInFile As ULong
    Public RecordLength As Integer
    Public Const cHeaderSize As Integer = 1024
    Public Const MAX_NUM_POINT_FREE_FORM As Integer = 40
    Public Enum STATE_ENUM As Byte
        'тип теста
        STATE_UNKNOWN = 0                   ' Нет данных.
        TEST_TENSION = 33                   ' Запущен тест "Растяжение".
        TEST_COMPRESSION = 35               ' Запущен тест "Сжатие".
        TEST_CONTROL = 36                   ' Запущен тест "Поддержание заданного параметра".
        TEST_CYCLING_SINE = 37              ' Запущен тест "Циклирование - синусоида".
        TEST_CYCLING_MEANDER = 38           ' Запущен тест "Циклирование - меандр".
        TEST_CYCLING_TRIANGLE = 39          ' Запущен тест "Циклирование - треугольник".
        TEST_CYCLING_FREE_FORM = 40         ' Запущен тест "Циклирование - произвольная форма"	
    End Enum
    Public Enum TYPE_CONTROL_ENUM As Byte
        'Тип данных - перечисление типа контролируемого параметра.
        CONTROL_FORCE = 0                   ' Контролируемая величина - усилие
        CONTROL_MOVING = 1                  ' Контролируемая величина - перемещение траверсы
        CONTROL_DEFORMATION = 2             ' Контролируемая величина - деформация
    End Enum
    Public FORMAT_EXP_POINT_bit As BitArray
  
    'такое в VB провернуть не получится 
    'вместо этой структуры будем работать с ChckLstBoxEnableResults
    Public Structure FORMAT_EXP_POINT_bool
        'Tип данных определяет формат одной записи файла экспорта.
        Public IsTimeRecorded As Boolean                'Создавать метку времени (мс).
        Public IsForceRecorded As Boolean               'Создавать запись усилия в 0,1 Н.
        Public IsMovingRecorded As Boolean              'Создавать запись перемещения в 0,0001 мм.
        Public IsDeformationRecorded As Boolean         'Создавать запись деформации в 0,0001 мм
        Public IsExtDeformationRecorded As Boolean      'Создавать запись деформации (доп. канал) в 0,0001 мм.
        Public IsVoltageRecorded As Boolean             'Создавать запись точек разности потенциала в 0,0001 мВ.
        Public IsTemperatureRecorded As Boolean         'Создавать запись точек разности потенциала в 0,0001 мВ.
        Public RESERVED As Boolean
    End Structure
    Public FORMAT_EXP_POINT_Flags As FORMAT_EXP_POINT_bool
    Public Structure RecordInFile
        Public Time As Integer
        Public Force As Integer
        Public Stoke As Integer ' or PD ref for msd files
        Public Strain As Integer
        Public ExtStrain As Integer
        Public Voltage As Integer
        Public Temperature As Integer
    End Structure
    Public RecordsArray() As RecordInFile
    Public Structure HEADER_EXP_FILE
        ' Первый блок 16*4=64 байт;
        ' Прореживание точек при формировании файла экспорта: 0 - файл не создается; 1 - прореживания 
        ' исходных данных нет; 2 - пишется каждая вторая точка; 3 - каждая третья точка;......
        Public ExpPrescaler As Integer
        ' Формат одной записи файла экспорта.
        Public FormatExportPoint As Byte     '8+24 бита
        Public RESERVE1 As Byte
        Public RESERVE2 As Byte
        Public RESERVE3 As Byte
        ' Тип теста.
        Public TypeTest As STATE_ENUM               '1 байт
        Public NuCh() As Byte                       'unsigned char NuCh[3];
        Public NuI32() As Integer                     'int32_t NuI32[13];
    End Structure

    Public Structure TestTensionCompressionSettings
        'Параметры испытаний "Растяжение" и "Сжатие".
        'Предварительная скорость траверсы в 0.001 мм/мин.
        Public PrevSpeed As Integer
        'Значение усилия, ниже которого скорость траверсы равна PrevSpeed.
        Public ForcePrevSpeed As Integer
        'Рабочая скорость траверсы в 0.001 мм/мин.
        Public WorkSpeed As Integer
    End Structure
    Public Structure TestControlSettings
        'Параметры испытания "Поддержание заданного параметра".
        'Тип контролируемого параметра.
        Public TYPE_CONTROL_ENUM As TYPE_CONTROL_ENUM
        'Заданное значение.
        Public CtrlVal As Integer
        'Время поддержания в секундах.
        Public TimeVal As Integer 'UNSIGNED
    End Structure
    Public Structure TestCyclingSettings
        'Параметры испытаний "Циклирование - синусоида", "Циклирование - меандр" и "Циклирование - треугольник".
        'Тип контролируемого параметра.
        Public TYPE_CONTROL_ENUM As TYPE_CONTROL_ENUM
        'Среднее значение.
        Public MeanVal As Integer
        'Переменное значение.
        Public AltVal As Integer
        'База (заданное колличество циклов).
        Public NumberCycles As Integer
        'Период сигнала в мс.
        Public Period As Integer
    End Structure

    Public Structure TestFreeFormSettings
        'Параметры испытания  "Циклирование - произвольная форма".
        '			// Тип контролируемого параметра.
        Public TYPE_CONTROL_ENUM As TYPE_CONTROL_ENUM
        'Колличество точек формы сигнала (1...40)
        Public NumPointsFreeForm As Byte '			unsigned char NumPointsFreeForm;
        '			// Заданное значение.
        Public Val() As Integer '			int32_t Val[MAX_NUM_POINT_FREE_FORM];
        '			// Время выхода в точку, мс
        Public TimeGoTo() As UInteger '			uint32_t TimeGoTo[MAX_NUM_POINT_FREE_FORM];
        '			// Время поддержания точки, мс
        Public TimeKeep() As UInteger '			uint32_t TimeKeep[MAX_NUM_POINT_FREE_FORM];
        '			// База (заданное колличество циклов).
        Public NumberCycles As Integer '			uint32_t NumberCycles;
    End Structure

    Public File_Head As HEADER_EXP_FILE
    Public Settings_TensComp As TestTensionCompressionSettings
    Public Settings_Contr As TestControlSettings
    Public Settings_Cyc As TestCyclingSettings
    Public Settings_FreeForm As TestFreeFormSettings

End Module



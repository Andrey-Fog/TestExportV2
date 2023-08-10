Module ModuleFunctions

    Function fGetBit(InitialByte As Byte, BitNumber As Byte) As Byte
        fGetBit = -((InitialByte And 2 ^ BitNumber) <> 0)
    End Function
End Module

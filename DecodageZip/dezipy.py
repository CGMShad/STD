import os
import struct


FILE_PATH = "POO.zip"
HeaderSize = 30
start = 0
end = 0

file = open(FILE_PATH,"rb") #Read Byte
result = file.read() #Lire le fichier

def getHeader(begin) :
    start = begin
    end = HeaderSize

    #Recupérer les éléments défini
    header = struct.unpack_from("4s2s2s2s2s2s4s4s4s2s2s",result[start:end])
    LocalFileHeader = int.from_bytes(header[0],'little')
    VersionNeeded = int.from_bytes(header[1],'little')
    GeneralFlag = int.from_bytes(header[2],'little')
    CompressionMethod = int.from_bytes(header[3],'little')
    FileLastTime = int.from_bytes(header[4],'little')
    FileLastDate = int.from_bytes(header[5],'little')
    CRC32 = int.from_bytes(header[6],'little')
    CompressedSize = int.from_bytes(header[7],'little')
    UncompressedSize = int.from_bytes(header[8],'little')
    FileNameLength = int.from_bytes(header[9],'little')
    ExtraFieldLength = int.from_bytes(header[10],'little')


    start = end
    end = start + FileNameLength + ExtraFieldLength

    #Récupéré les éléments à tailles variables
    name= struct.unpack_from(str(FileNameLength)+'s' + str(ExtraFieldLength) + 's',result[start:end])
    FullName = name[0].decode('utf-8')
    ExtraField = name[1].decode('utf-8')

    #Affichage
    print("____Start of file____")
    print("Local file header : " , hex(LocalFileHeader))
    print("Version needed : ", VersionNeeded)
    print("General bit flag : ", GeneralFlag)
    print("CompressionMethod : " , CompressionMethod)
    print("FileLastTime : " , FileLastTime)
    print("FileLastDate : " , FileLastDate)
    print("CRC32 : " , CRC32)
    print("CompressedSize : ", CompressedSize)
    print("UncompressedSize : ", UncompressedSize)
    print("FileNameLength : ", FileNameLength)
    print("ExtraFieldLength : ", ExtraFieldLength)
    print("Name : " , FullName)
    print("ExtraField : ", ExtraField)
    print("____End of file____")

getHeader(0)

import os
import struct


FILE_PATH = "song.mp3"

file = open(FILE_PATH,"rb")
result = file.read() 

endFile = 10
header = struct.unpack("3s7b",result[0:endFile])
taille = (header[5] << 14) + (header[6] << 7) + (header[7])
print(header)
print(taille)
print(header[0].decode("utf-8"))

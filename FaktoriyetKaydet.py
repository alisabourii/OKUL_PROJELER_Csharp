def fakto(deger):
    topla = 1
    for i in range(1,deger):
        topla *= i
    return topla

degerler = []
counter = 0

while 1:
    giris = int(input("Değer giriniz(Çıkış için 1): "))
    if giris == 1:
        break
    faktDeger = fakto(giris)
    degerler.append(str(counter)+":"+str(faktDeger)+"\n")
    counter += 1
    file = open("faktSonuclar.txt","w+")
    file.writelines(degerler)
    file.close()

for _ in range(20):
    print("-", end="-")
print()

fileOku = open("faktSonuclar.txt","r+")
listeFile = fileOku.readlines()
listStr = ""
for i in listeFile:
    listStr += i
print(listStr)
fileOku.close()
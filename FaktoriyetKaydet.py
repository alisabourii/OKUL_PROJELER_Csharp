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
    print("Sonuç: "+str(faktDeger))
    counter += 1
file = open("faktSonuclar.txt","w+")
file.writelines(degerler)
print(degerler)
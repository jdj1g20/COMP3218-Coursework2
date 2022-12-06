from tkinter import *
import json
window=Tk()
# add widgets here
properties = ['military','economy','religion','food','social']
advisors = ['militaryA','economyA','religionA','foodA','socialA','catA']

def callback(self, P):
    if str.isdigit(P) and int(P) >= 0 and int(P) <= 10:
        return True
    else:
        return False

def retrieve_input(textBox):
    inputValue=textBox.get("1.0","end-1c")
    return inputValue

tfDesc=Text(window,height = 5, width=40)
tfDesc.grid(row=0,column=1)

variable = StringVar(window)
omAdv=OptionMenu(window,variable,*advisors)
omAdv.grid(row=1,column=1)

v1 = StringVar()
l1 = Label(window, textvariable=v1)
v1.set("Responds yes")
l1.grid(row=2,column=1)


variable11 = StringVar(window)
oms11=OptionMenu(window,variable11,*properties)
oms11.grid(row=3,column=1)

variable12 = StringVar(window)
oms12=OptionMenu(window,variable12,*properties)
oms12.grid(row=4,column=1)

tfDesc1=Text(window,height = 5, width=40)
tfDesc1.grid(row=5,column=1)

teInp11 = Entry(window)
teInp11.grid(row = 3, column=2)



teInp12 = Entry(window)
teInp12.grid(row = 4, column=2)

v1 = StringVar()
l1 = Label(window, textvariable=v1)
v1.set("Responds no")
l1.grid(row=6,column=1)

variable21 = StringVar(window)
om21=OptionMenu(window,variable21,*properties)
om21.grid(row=7,column=1)

variable22 = StringVar(window)
om22=OptionMenu(window,variable22,*properties)
om22.grid(row=8,column=1)

teInp21 = Entry(window)
teInp21.grid(row = 7, column=2)

teInp22 = Entry(window)
teInp22.grid(row = 8, column=2)

tfDesc2=Text(window,height = 5, width=40)
tfDesc2.grid(row=9,column=1)

v1 = StringVar()
l1 = Label(window, textvariable=v1)
v1.set("description: ")
l1.grid(row=0,column=0)

v2 = StringVar()
l2 = Label(window, textvariable=v2)
v2.set("advisor: ")
l2.grid(row=1,column=0)

v3 = StringVar()
l3 = Label(window, textvariable=v3)
v3.set("stat1: ")
l3.grid(row=3,column=0)

v4 = StringVar()
l4 = Label(window, textvariable=v4)
v4.set("stat2: ")
l4.grid(row=4,column=0)

v5 = StringVar()
l5 = Label(window, textvariable=v5)
v5.set("description: ")
l5.grid(row=5,column=0)


v6 = StringVar()
l6 = Label(window, textvariable=v6)
v6.set("stat1: ")
l6.grid(row=7,column=0)


v7 = StringVar()
l7 = Label(window, textvariable=v7)
v7.set("stat2: ")
l7.grid(row=8,column=0)


v8 = StringVar()
l8 = Label(window, textvariable=v8)
v8.set("description: ")
l8.grid(row=9,column=0)

def printJson():
    j = json.dumps({
        'description':retrieve_input(tfDesc), 
        'advisor':variable.get(), 
        'consequence':[{
            'desicion':True,
            'stat1':variable11.get(),
            'mod1':teInp11.get(),
            'stat2':variable12.get(),
            'mod2':teInp12.get(),
            'description':retrieve_input(tfDesc1)},
            {'desicion':False,
            'stat1':variable21.get(),
            'mod1':teInp21.get(),
            'stat2':variable22.get(),
            'mod2':teInp22.get(),
            'description':retrieve_input(tfDesc2)}]})
    print(j)
bgen = Button(window,command=printJson)
bgen.grid(row = 10, column=1)





#{descp: String, adv: Advisor, consq: {{desci:True,stat1: +int, stat2:-int}{desci:False,stat1: -int, stat2:+int}}} 



#drop down menu for advisor


window.title('Hello Python')
window.geometry("300x200+10+20")
window.mainloop()




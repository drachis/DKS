import math
import random

class dragon_egg(object):
    '''
    This is a dragon egg that will grow and develop through the game.
    '''
    def __init__(self,element = [0,-.9]):
        self.age = 0 #start off the game with no age, at some age the egg hatches

        #the egg starts off with a neutral elemental alignment
        #2d coordinate for elemnt because of elemental oposition [fire-water,air-earth]
        #[1,1] = fire + air , [-1,-1] = water,earth 
        self.element=element #should be in the range 0,1
        self.descriptors=[
            'neutraly ',
            'a pinch ',
            'a little ',
            'somewhat ',
            'very much ',
            'entirely '
            ]
        self.elements=[
            'fire',
            'water',
            'air',
            'earth'
            ]
        self.name=''
        self.niceName=''
    def _align_mag(self):
        #uses the values in self.element to determin in words how much
        numDescriptors=len(self.descriptors)-1
        descriptors=[]
        for element in self.element:
            n = math.fabs(round(element*numDescriptors))
            descriptors.append(self.descriptors[int(n)])
        return descriptors
    def _align_ele(self):
        ele=[]
        eleRad=(math.atan2(self.element[0],self.element[1]))/math.pi
        if eleRad<0:
            ele.append(self.elements[0])
        else:
            ele.append(self.elements[1])
        if math.fabs(eleRad)<.5:
            ele.append(self.elements[2])
        else:
            ele.append(self.elements[3])
        return ele
    def check_element(self):
        ele=self._align_ele()
        mag=self._align_mag()
        n = ''
        if self.name != '':    
            n = ' ' + self.name
        print 'This egg{name} is {mag0} aligned to {ele0} and {mag1} aligned to {ele1}'.format(
            name=n,
            mag0=mag[0],
            ele0=ele[0],
            mag1=mag[1],
            ele1=ele[1]
        )
    def modify_element(self,change):
        for i,element in enumerate(self.element):
            self.element[i]+=change[i]
    def set_name(self,name):
        # name the egg
        self.name=name
        
if __name__ == '__main__':
    egg0 = dragon_egg(element=[random.random()*2-1, random.random()*2-1])
    egg0.set_name('George')
    egg0.check_element()
    #egg0.modify_element(change=(-random.random()*2-1,random.random()*2-1))    
    #egg0.check_element()
    print('\n')
    egg1 = dragon_egg(element=[random.random()*2-1, random.random()*2-1])
    egg2 = dragon_egg(element=[random.random()*2-1, random.random()*2-1])  
    egg1.check_element()
    egg2.check_element()

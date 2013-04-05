import math

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
        self.descriptors={
            0 : 'neutraly ',
            1 : 'a pinch ',
            2 : 'a little ',
            3 : 'somewhat ',
            4 : 'very much ',
            5 : 'entirely '
            }
        self.elements={
            0 : 'fire',
            1 : 'water',
            2 : 'air',
            3 : 'earth'
            }
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
        if math.fabs(eleRad)>.5:
            ele.append(self.elements[3])
        else:
            ele.append(self.elements[2])
        return ele
    def check_element(self):
        ele=self._align_ele()
        mag=self._align_mag()

        print 'This egg%s is %saligned to %s and %saligned to %s'%(self.niceName,mag[0],ele[0],mag[1],ele[1])
    def modify_element(self,change):
        for i,element in enumerate(self.element):
            self.element[i]+=change[i]
    def set_name(self,name):
        # name the egg
        self.name=name
        self.niceName=', '+name+','
        
if __name__ == '__main__':
    egg0 = dragon_egg(element=[.2,.0])
    egg1 = dragon_egg(element=[.5,.5])
    egg2 = dragon_egg(element=[-.5,-.5])
    egg0.check_element()
    egg0.modify_element(change=(-.5,-.5))
    egg0.set_name('George')
    egg0.check_element()
    print('\n')
    egg1.check_element()
    egg2.check_element()

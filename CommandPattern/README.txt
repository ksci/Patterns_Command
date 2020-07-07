/*Author:       Kyle Miller
 * Project:     Command Pattern CS 3450
 * Purpose:     Build a program that reads in a file, makes command objects
 * and then executes those commands.  Finally, undo those commands
 * 
 * Declaration: I wrote all this code.
 * 
 */

A few comments:
Originally I had all of the factory, parsing, and invoker code in my main program, but decided for readability
to push all that into separate classes.  Since this code is meant to prove a point and not be reused I 
decided to just make these all static classes.  This means that they are fairly tightly coupled and are
aware of eachother.  I excluded the factory idiom and parser from the UML for this reason.  I left the 
invoker just for claritys sake since most instances of this pattern use a separate invoker object (remote control
or similar.)  

I also wrote a GUI version of this program that reads in the same file and displays the commands as a checklist
style history display.  I wanted to simulate the history feature that you find in programs like photoshop that
simply have a list of everything you have done recently and which allow you to quickly click back to a previous
state.  Because that program was more for fun I did not take the time to tidy up my classes and you will find
the invoker, factory and parser all still part of main.  You can find that program under the CommandGUI 
folder.
# README

Brief tutorial on how to use git

- I prefer using the terminal to do all my git magic because I understand it and I find that the GUIs Ive used in the past to be clunky and not as intuitive, but if you prefer go ahead and use a GUI.

- If you are confused or lost in it don't be afraid to ask for help. You can either text me or slack message me and Ill try to get back to you ASAP. Git is fantastic but it can be kind of daunting at times.

- SETUP:
	1. first install git on your machine if you havn't already (https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
	2. Clone the repository to your local machine if you havn't already using this command: git clone https://github.com/kelleyschaefer/DoomDayCare.git
		- Create a folder to clone the project to, you can call it 'capstone_prototype' for example
		- For PC: Right click in the folder and select 'Git Bash Here'
		- For Mac: using the terminal navigate to the folder you just created
			- cd directory_name (use this command to navigate to your file)
			- cd .. (goes back up one directory)
		- Then type the above command into the console and hit enter (this will create a copy of the repository on your local machine)


- Workflow:
	1. First you will create a new branch to work off of using this command: git branch name_of_your_branch master
	2. Now have fun making all the changes and alterations to the project you want =)
	3. After altering/adding your changes add them with this command: git add -A
		- this will add all changed files, minus those being ignored by the .gitignore
	4. Now commit those changes to the branch you made with this command: git commit -m "your message goes here"
	5. Now you are ready for review. Have someone, or several people review your work and get it approved.
	6. After it has been approved we can then merge it to the master branch and push it up to the main repository stored on Github. Probably Matthew or Kelley will help with this step, unless you feel confident in your git foo.

One of the great things about git is that it creates kind of a snapshot of your progress and saves it. Whenever you make a commit those changes are saved. So if something terrible happens and you destroyed all of your work on accident, as long as you have a previous commit we can always get back to a working project. =) Git makes collaboration easy, err... easier 

//========= VARIABLES =========//

const electron = require('electron');
const path = require('path');
const { app, BrowserWindow, Tray } = electron;


//========= EXPORTS =========//



//========= WIN =========//

//************************//
//Initialize the app
//************************//
app.on('ready', function()
{
	//const appIcon = new Tray('./RES/icon.ico');
	
	let win = new BrowserWindow (
	{
		minWidth: 1400,
		minHeight: 800,
		width: 1400,
		height: 800,
		title: "Backend",
		//icon: path.join(__dirname, '/asset/app-icon/icon.ico'),
		backgroundColor: '#fcfcfc',
		frame: true
	}); 

	win.setTitle("Graph");

	win.loadURL(path.join('file://', __dirname, 'html/index.html'));
});

app.on('window-all-closed', () => {
	if (process.platform !== 'darwin')
	{
		app.quit();
	}
});

app.on('activate', () => {
	if (win === null)
	{
		createWindow();
	}
});
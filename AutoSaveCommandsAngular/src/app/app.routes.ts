import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { HttpRequestsComponent } from './httprequests/httprequests.component';
import { CommandsComponent } from './commands/commands.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'httprequests', component: HttpRequestsComponent },
    { path: 'commands', component: CommandsComponent }
];

export const routing = RouterModule.forRoot(appRoutes);

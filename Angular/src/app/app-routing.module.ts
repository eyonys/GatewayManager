import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GatewaysComponent } from './gateways/gateways.component';
import { GatewayDetailsComponent } from './gateway-details/gateway-details.component';
import { GatewayAddComponent } from './gateway-add/gateway-add.component';
import { PeripheralAddComponent } from './peripheral-add/peripheral-add.component';


const routes: Routes =
    [
        { path: '', component: GatewaysComponent, pathMatch: 'full' },
        { path: 'gateways/:id', component: GatewayDetailsComponent },
        { path: 'add', component: GatewayAddComponent },
        { path: 'addpd/:id', component: PeripheralAddComponent },
        { path: '**', redirectTo: '/' }
    ];

@NgModule(
    {
        imports: [RouterModule.forRoot(routes)],
        exports: [RouterModule]
    })
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { UserProfileComponent } from '../../paginas/user-profile/user-profile.component';
import { TableListComponent } from '../../paginas/table-list/table-list.component';
import { TypographyComponent } from '../../paginas/typography/typography.component';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatRippleModule} from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import { IconsComponent } from 'app/paginas/icons/icons.component';
import { MapsComponent } from 'app/paginas/maps/maps.component';
import { UpgradeComponent } from 'app/paginas/upgrade/upgrade.component';
import { NotificationsComponent } from 'app/paginas/notifications/notifications.component';
import { DashboardComponent } from 'app/paginas/dashboard/dashboard.component';
import { ProdutosComponent } from 'app/paginas/produtos/produtos.component';
import { MarcasComponent } from 'app/paginas/marcas/marcas.component';
import { DepartamentoComponent } from 'app/paginas/departamentos/departamentos.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TableListComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    UpgradeComponent,
    ProdutosComponent,
    MarcasComponent,
    DepartamentoComponent
  ]
})

export class AdminLayoutModule {}

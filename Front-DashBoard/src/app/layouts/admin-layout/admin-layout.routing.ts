import { Routes } from '@angular/router';

import { UserProfileComponent } from '../../paginas/user-profile/user-profile.component';
import { TableListComponent } from '../../paginas/table-list/table-list.component';
import { TypographyComponent } from '../../paginas/typography/typography.component';
import { UpgradeComponent } from '../../paginas/upgrade/upgrade.component';
import { DashboardComponent } from 'app/paginas/dashboard/dashboard.component';
import { IconsComponent } from 'app/paginas/icons/icons.component';
import { MapsComponent } from 'app/paginas/maps/maps.component';
import { NotificationsComponent } from 'app/paginas/notifications/notifications.component';
import { ProdutosComponent } from 'app/paginas/produtos/produtos.component';
import { MarcasComponent } from 'app/paginas/marcas/marcas.component';

export const AdminLayoutRoutes: Routes = [
    // {
    //   path: '',
    //   children: [ {
    //     path: 'dashboard',
    //     component: DashboardComponent
    // }]}, {
    // path: '',
    // children: [ {
    //   path: 'userprofile',
    //   component: UserProfileComponent
    // }]
    // }, {
    //   path: '',
    //   children: [ {
    //     path: 'icons',
    //     component: IconsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'notifications',
    //         component: NotificationsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'maps',
    //         component: MapsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'typography',
    //         component: TypographyComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'upgrade',
    //         component: UpgradeComponent
    //     }]
    // }
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'table-list',     component: TableListComponent },
    { path: 'typography',     component: TypographyComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'notifications',  component: NotificationsComponent },
    { path: 'upgrade',        component: UpgradeComponent },
    { path: 'produtos',       component: ProdutosComponent },
    { path: 'marcas',       component: MarcasComponent },
];

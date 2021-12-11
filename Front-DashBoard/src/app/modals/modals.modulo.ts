import { ProdutoFormComponent } from "./produto-form/produto-form.component";
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { CommonModule } from "@angular/common";
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { ComponentsModule } from "app/components/components.module";
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { NgModule } from "@angular/core";
import { MarcaFormComponent } from "./marca-form/marca-form.component";

export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;

@NgModule({
  declarations: [
      ProdutoFormComponent,
      MarcaFormComponent
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbPaginationModule,
    MatSelectModule,
    MatInputModule,
    MatCheckboxModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [],
  exports: [
    
  ],
  entryComponents: [
  ]
})

export class ModalsModule { }

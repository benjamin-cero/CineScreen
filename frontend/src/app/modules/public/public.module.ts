import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {TranslateModule} from '@ngx-translate/core';

import {PublicRoutingModule} from './public-routing.module';
import {AboutComponent} from './about/about.component';
import {BlogComponent} from './blog/blog.component';
import {ContactUsComponent} from './contact-us/contact-us.component';
import {HomeComponent} from './home/home.component';
import {PublicLayoutComponent} from './public-layout/public-layout.component';
import {TravelsComponent} from './travels/travels.component';
import {FormsModule} from '@angular/forms';

// Home child components
import {FeaturedMoviesComponent} from './home/featured-movies/featured-movies.component';
import {MovieCategoriesComponent} from './home/movie-categories/movie-categories.component';
import {MenuSectionComponent} from './home/menu-section/menu-section.component';
import {StatisticsComponent} from './home/statistics/statistics.component';
import {CtaSectionComponent} from './home/cta-section/cta-section.component';

// Angular Material Modules
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatChipsModule} from '@angular/material/chips';
import {MatButtonModule} from '@angular/material/button';
import {SeatSelectionComponent} from './seat-selection/seat-selection.component';

@NgModule({
  declarations: [
    AboutComponent,
    BlogComponent,
    ContactUsComponent,
    PublicLayoutComponent,
    TravelsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    PublicRoutingModule,
    FormsModule,
    TranslateModule,
    // Angular Material Modules
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatChipsModule,
    MatButtonModule,
    FeaturedMoviesComponent,
    MovieCategoriesComponent,
    MenuSectionComponent,
    StatisticsComponent,
    CtaSectionComponent,
    HomeComponent,
    SeatSelectionComponent
  ],

})
export class PublicModule {
}

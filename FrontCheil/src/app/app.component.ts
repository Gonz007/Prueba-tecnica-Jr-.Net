import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Hotel } from './Interfaces/hotel';
import { HotelService } from './Services/hotel.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['id', 'name', 'stars', 'actions'];
  dataSource = new MatTableDataSource<Hotel>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private hotelService: HotelService, private sanitizer: DomSanitizer) {}

  ngOnInit(): void {
    this.showHotels(1, 100);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  

  showHotels(pageNumber: number, rowsPerPage: number): void {
    this.hotelService.getList(pageNumber, rowsPerPage).subscribe({
      next: (dataResponse: any) => {
        const dataArray = dataResponse.getInfoDetail;
        
        // Agregar imágenes aleatorias a cada elemento del array
        dataArray.forEach((element: Hotel) => {
          this.obtenerImagenAleatoria(element);
        });
        

        this.dataSource = new MatTableDataSource(dataArray);
        this.dataSource.paginator = this.paginator;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  obtenerImagenAleatoria(element: Hotel): void {
    const numeroAleatorio = Math.floor(Math.random() * 6) + 1; // Ajusta según el rango de tus imágenes
    const urlImagen = `assets/Images/${numeroAleatorio}.jpg`;
    element.randomImage = this.sanitizer.bypassSecurityTrustUrl(urlImagen);
  }
}

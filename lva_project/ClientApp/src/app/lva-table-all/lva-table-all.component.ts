import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { LvaService } from '../lva.service';
import { Lva } from '../models/lva';

@Component({
  selector: 'app-lva-table-all',
  templateUrl: './lva-table-all.component.html',
  styleUrls: ['./lva-table-all.component.css']
})
export class LvaTableAllComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<Lva[]>;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = [
    "lvaId",
    "lvaName",
    "lvaTeacher",
    "lvaNumber",
    "lvaType",
    "lvaEcts"
  ]  
  dataSource: Lva[] = [];
  dataSource$: Observable<Lva[]> = new Observable;
  ds!: MatTableDataSource<Lva>;

  // dataSource: MatTableDataSource<LvaTableAllDataSource> | null; 

  constructor(private readonly _lvaService: LvaService) {
    
  }

  ngOnInit(): void {
    this.dataSource$ = this._lvaService.getLvas();
    this._lvaService.getLvas().subscribe(d => {
      this.dataSource = d;
      this.ds = new MatTableDataSource(this.dataSource);
      console.log(this.dataSource[0].lvaName);
    })
    // this.dataSource.sort = this.sort;
    // this.dataSource.paginator = this.paginator;
    


  }
}

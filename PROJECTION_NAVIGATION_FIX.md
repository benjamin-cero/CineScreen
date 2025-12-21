# Projection Navigation Fix

## Issue
When clicking on projection time buttons (e.g., "Moana 2 16:00 2D Hall1"), the navigation was failing and going to `http://localhost:5174/cinemahalls/undefined` instead of the seat selection page.

## Root Cause
**Field Name Mismatch**: The backend C# API returns field names in PascalCase (uppercase first letter) like `ID`, `MovieID`, `StartTime`, etc., but the frontend TypeScript interfaces were expecting camelCase (lowercase first letter) like `id`, `movieId`, `startTime`, etc.

This caused `projection.id` to be `undefined` when the actual field was `projection.ID`.

## Solution
Updated all frontend interfaces and references to match the backend PascalCase naming convention:

### Files Modified

#### 1. `projection-get-all-endpoint.service.ts`
```typescript
// Before
export interface ProjectionGetAllResponse {
  id: number;
  cinemaHallID: number;
  movieID: number;
  // ...
}

// After
export interface ProjectionGetAllResponse {
  ID: number;
  CinemaHallID: number;
  MovieID: number;
  StartTime: string;
  Price: number;
  // ...
}
```

#### 2. `projection-get-by-id-endpoint.service.ts`
```typescript
// Before
export interface ProjectionGetByIdResponse {
  id: number;
  cinemaHallId: number;
  movieId: number;
  // ...
}

// After
export interface ProjectionGetByIdResponse {
  ID: number;
  CinemaHallID: number;
  MovieID: number;
  StartTime: string;
  Price: number;
  // ...
}
```

#### 3. `movies.component.ts`
- Updated projection filtering: `p.movieID` → `p.MovieID`
- Updated field references: `projection.movieTypeID` → `projection.MovieTypeID`
- Updated navigation: `projection.id` → `projection.ID`
- Updated date processing: `p.startTime` → `p.StartTime`

#### 4. `seat-selection.component.ts`
- Updated price access: `projection.price` → `projection.Price`
- Updated field access: `projection.movieId` → `projection.MovieID`
- Updated field access: `projection.cinemaHallId` → `projection.CinemaHallID`

#### 5. `seat-selection.component.html`
- Updated template: `projection!.startTime` → `projection!.StartTime`

## Backend Field Names (C# PascalCase)
- `ID` - Projection identifier
- `MovieID` - Movie identifier  
- `CinemaHallID` - Cinema hall identifier
- `MovieTypeID` - Movie type identifier
- `StartTime` - Projection start time
- `Price` - Ticket price
- `MovieTitle` - Movie title
- `CinemaHallName` - Cinema hall name
- `MovieTypeName` - Movie type name

## Result
✅ Projection navigation now works correctly
✅ Clicking projection time buttons navigates to `/public/seat-selection/:projectionId`
✅ All projection data is properly accessible
✅ Seat selection component receives correct projection data

## Testing
1. Go to movies page (`/public/movies`)
2. Click on any projection time button (e.g., "16:00")
3. Should navigate to seat selection page with proper projection data
4. All movie, cinema hall, and projection information should display correctly

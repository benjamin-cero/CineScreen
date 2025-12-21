# Seat Selection Feature

## Overview
A modern, interactive cinema seat selection component that allows users to visually select seats for movie projections.

## Features Implemented

### 1. **Cinema Hall Visualization**
- Visual representation of the cinema hall layout
- Screen indicator at the top
- Proper seat arrangement based on the seed data structure
- Row labels (A, B, C, D, E, F, W for wheelchair, L for love seats)

### 2. **Seat Types & Pricing**
- **Regular Seats**: Base price (1.0x multiplier)
- **Love Seats**: Premium pricing (+50% or 1.5x multiplier)
- **Wheelchair Seats**: Base price (1.0x multiplier)
- Dynamic pricing calculation based on seat type selection

### 3. **Seat States**
- **Available**: Green gradient (regular), red gradient (love), blue gradient (wheelchair)
- **Selected**: Golden gradient with scale animation
- **Occupied**: Gray gradient, disabled state
- Interactive hover effects with scaling and shadows

### 4. **User Interaction**
- Ticket quantity selector with +/- buttons
- Seat selection limited to selected ticket quantity
- Real-time price calculation
- Selected seats summary with removable chips
- Tooltips showing seat information and pricing

### 5. **Modern UI Design**
- Glass morphism design with backdrop blur effects
- Gradient backgrounds and modern color scheme
- Responsive design for mobile and desktop
- Material Design icons and components
- Smooth animations and transitions

### 6. **Data Integration**
- Fetches projection details from backend
- Loads movie, cinema hall, and seat information
- Checks occupied seats from existing tickets
- Proper error handling and loading states

## Technical Implementation

### Components Created
- `SeatSelectionComponent`: Main component handling seat selection logic
- `seat-selection.component.html`: Template with cinema hall layout
- `seat-selection.component.css`: Modern styling with gradients and animations

### Navigation Integration
- Added route: `/public/seat-selection/:projectionId`
- Updated movies component to navigate to seat selection
- Integrated with existing routing structure

### Data Flow
1. User clicks projection time button in movies component
2. Navigates to seat selection with projection ID
3. Loads projection, movie, cinema hall, seats, and ticket data
4. Processes seat layout into rows
5. Displays interactive seat grid
6. Handles seat selection and pricing calculations

## Key Features

### Visual Design
- **Screen Visualization**: Clear screen indicator with TV icon
- **Seat Legend**: Visual guide showing different seat types
- **Row Layout**: Proper cinema hall arrangement with gaps for aisles
- **Color Coding**: Intuitive color scheme for seat states

### Functionality
- **Quantity Control**: Easy ticket quantity adjustment
- **Seat Selection**: Click to select/deselect seats
- **Price Calculation**: Real-time total price updates
- **Validation**: Prevents over-selection of seats
- **Responsive**: Works on all device sizes

### User Experience
- **Intuitive Interface**: Easy to understand and use
- **Visual Feedback**: Clear indication of seat states
- **Error Handling**: User-friendly error messages
- **Loading States**: Smooth loading experience
- **Accessibility**: Proper ARIA labels and keyboard navigation

## Usage

1. Navigate to movies page
2. Click on any projection time button
3. Select desired number of tickets
4. Click on seats to select them
5. Review selection and total price
6. Proceed to checkout (placeholder functionality)

## Future Enhancements
- Ticket purchase integration
- Payment processing
- Seat reservation with time limits
- User authentication integration
- Email confirmation
- QR code generation for tickets

## Files Modified/Created

### New Files
- `frontend/src/app/modules/public/seat-selection/seat-selection.component.ts`
- `frontend/src/app/modules/public/seat-selection/seat-selection.component.html`
- `frontend/src/app/modules/public/seat-selection/seat-selection.component.css`

### Modified Files
- `frontend/src/app/modules/public/public-routing.module.ts`
- `frontend/src/app/modules/public/movies/movies.component.ts`

## Seed Data Integration
The component properly handles the seed data structure:
- Cinema halls with 60 seats each
- Mixed seat types (Regular, Love, Wheelchair)
- Existing ticket reservations
- Projection pricing based on movie type (2D: $5, 3D: $7, IMAX: $10)

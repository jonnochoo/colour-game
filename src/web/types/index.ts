export interface ChoreList {
    name: string
    chores: Chore[]
}

export interface Chore {
    description: string
    category: Category
    frequencyType: FrequencyType
    isCompleted: Boolean
}

export type Category = 'morning' | 'afternoon' | 'evening'

export type DayOfWeek =
    | 'Sunday'
    | 'Monday'
    | 'Tuesday'
    | 'Wednesday'
    | 'Thursday'
    | 'Friday'
    | 'Saturday'

export interface FrequencyType {
    $type: string
}

export interface WeeklyFrequencyType extends FrequencyType {
    daysOfWeek: DayOfWeek[]
}

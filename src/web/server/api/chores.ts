import {
    type Chore,
    type ChoreList,
    type DayOfWeek,
    type Category,
    type FrequencyType,
    type WeeklyFrequencyType,
} from '~/types'

export default defineEventHandler(async (event) => {
    return [
        {
            name: 'Abigail',
            imageUrls: [
                'https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExOHA2ZDNmajR1c3cwZHFrNmpueTB2YWZyejVjamkzd3B0OWtjNXZhdCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/KztT2c4u8mYYUiMKdJ/giphy.gif',
                'https://media.giphy.com/media/cd0cUsW1WY5EozBXLM/giphy.gif',
                'https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExNnlneXlrNW5lMXZnaHdnaWZhNzNxcHdvd25wdHNlY3R2ZnE0aDlrMyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/7sbFtBoKItOjeWb2yj/giphy.gif',
                'https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExYmZwNHNmZjB0c2wxa3F0bmNxcGM1eHdwODFva2ZndWRwdnMxcjd6YiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/td02jbtsXIxpBv45rJ/giphy.gif',
                'https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExaDRkNGt5Y296c2ZtcnljaDc1YmZiY3hjbzA2dXIwazNoa3pmN2RpNSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/xlcR4sYSBT34fQqApS/giphy.gif',
                'https://media0.giphy.com/media/9Y1LEFKsbbP4hrLgV3/giphy.gif?cid=ecf05e47kyxzb6msj6k3b7yecji3vc35h90yh4hyqfi2dg6g&ep=v1_gifs_related&rid=giphy.gif&ct=g',
                'https://media3.giphy.com/media/5bdhq6YF0szPaCEk9Y/giphy.gif?cid=ecf05e47dnsx1xz11yt59r333c7qp9kpgso9oem1wscjrcb5&ep=v1_gifs_related&rid=giphy.gif&ct=g',
                'https://media3.giphy.com/media/SILTTnZ7qHX2Y6Oqtm/giphy.gif?cid=ecf05e4725zysi1xbzb2j9frvt2ke214lkdf20snhtzoka9g&ep=v1_gifs_related&rid=giphy.gif&ct=g',
                'https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExeGFoa2c4bmpoeWpqd2JxM3p1dHRkamNtcm9id2R6c3QyY3lxZGpociZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/HzPtbOKyBoBFsK4hyc/giphy.gif',
                'https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExYnUyYnlqeHo0NTl2dG1oc2Q0Z25xd2Jla3p3aXYwaG55NDdncGZveSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/jsPdPJ1mkYiZrX0DHT/giphy.gif',
                'https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExaWNsb3h4dXltcTQ0c3F2ZWc1MHh5YnMwaGl5bHhtYmdjNXplaXBncyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/7sbFtBoKItOjeWb2yj/giphy.gif',
            ],
            chores: [
                createDailyMorningChores(
                    'Turn off lights and fans',
                    'ic:twotone-electric-bolt'
                ),
                // Morning
                createDailyMorningChores('👘Get changed out of PJs'),
                createDailyMorningChores('🥣Eat breakfast'),
                createDailyMorningChores('🧼Put breakfast dishes away'),
                createDailyMorningChores('🪥Brush teeth'),
                createDailyMorningChores('🪮Fix up hair'),
                createDailyMorningChores('☀️Sunscreen'),
                createDailyMorningChores('🔍Find hat, jacket, socks & shoes'),
                createMorningWeekly('Pack swimming bag', ['Friday', 'Tuesday']),

                createMorningWeekDayChore('Pack school bag'),

                createMorningWeekly('🩰Reminder about dance class', [
                    'Monday',
                    'Tuesday',
                ]),
                createMorningWeekly('Wear sports clothes', [
                    'Monday',
                    'Wednesday',
                ]),
                createMorningWeekly('Pack library bag', ['Tuesday']),
                createMorningWeekly('Pack gymanstics bag', ['Friday']),

                // Afternoon
                createDailyAfternoonChores('Unpack bag (especially lunch bag)'),
                createDailyAfternoonChores('Finish lunch'),
                createDailyAfternoonChores(
                    'Have a shower, cream and change into PJs'
                ),
                createDailyAfternoonChores('Do homework'),
                createDailyAfternoonChores('Put away clothes'),
                createDailyAfternoonChores('Ask Mummy if any other chores'),
                createAfternoonWeekDayChore('Piano practice with Mummy', [
                    'Wednesday',
                ]),

                // Evening
                createDailyEveningChores('Brush your teeth'),
            ],
        } as ChoreList,
        {
            name: 'Elijah',
            imageUrls: [
                'https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExejRxaW1zc3Rjb3o5MTY4MTZ6dXVveTduZGljaWF5bzR1N3MwMWl0NCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/TdfyKrN7HGTIY/giphy.gif',
                'https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExZHlhcDd0NHA3djdteWw0bWl5eHBsODRlOHhsMG14MmRrbm01dm85aiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/c1vzm6D1NPzm8/giphy.gif',
                'https://media4.giphy.com/media/jsTgk136sV71K/giphy.gif?cid=ecf05e47h0x08l4amuxtikjg34t2wq212tjmchyy69w3nqoq&ep=v1_gifs_related&rid=giphy.gif&ct=g',
                'https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExNTFiZGlsNHdpZ3d6a2o3ZGE5OGltbHF5bmViOTg0Z2NjOGlrY3MwaSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/l2olcETxXQjImhNcm2/giphy.gif',
                'https://media4.giphy.com/media/3o7absbD7PbTFQa0c8/giphy.gif?cid=ecf05e47jisepxu9wkii8dd9lal4io7ik41p7u8zb70rk8qu&ep=v1_gifs_related&rid=giphy.gif&ct=g',
                'https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExcWltMmVnejFreW5ibzNsMWMwMGd2Nm5wZThibXRsYzMzM2psb2doaiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/BrFuiMe3YUt3laSeEO/giphy.gif',
                'https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExcjZienF0azYwejZ3OTBrZmc0N3locXk2aTN0dHdmZTVlcXZwNzh6NiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/ojKMgAPZeerk21Allh/giphy.gif',
                'https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExMWlqM2dnNDZnOGd0cWFhYzUwaXA0emJrNG0xaWgyYjFsMnNlcGVzdSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3NtY188QaxDdC/giphy.gif',
                'https://media3.giphy.com/media/11sBLVxNs7v6WA/giphy.gif?cid=ecf05e47whnu417cb38pq730xb08qyclb1lvnrozbb9lvfsr&ep=v1_gifs_related&rid=giphy.gif&ct=g',
                'https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExd256cTV3cGFkcDhpN29oeG14OHh4cXMxazhuZnh5MjEzODc4Yzl2cCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3otPoo8NDLOmzvTJF6/giphy.gif',
                'https://media4.giphy.com/media/l1KtXmfi3EnjM5zpK/giphy.gif?cid=ecf05e47vjvhtgci6q4fpprh8vq1t0nwuhxexg3ktgv5q81l&ep=v1_gifs_related&rid=giphy.gif&ct=g',
            ],
            chores: [
                createDailyMorningChores('Turn off lights and fans'),
                createDailyMorningChores('Get changed out of PJs'),
                createDailyMorningChores('Eat breakfast'),
                createDailyMorningChores('Put breakfast dishes away'),
                createDailyMorningChores('Brush teeth'),
                createDailyMorningChores('Sunscreen'),
                createDailyMorningChores('Find hat, jacket, socks & shoes'),

                createMorningWeekDayChore('Pack school bag'),

                createMorningWeekly('Pack library bag', ['Tuesday']),
                createMorningWeekly('Pack cricket bag', [
                    'Wednesday',
                    'Saturday',
                ]),
                createMorningWeekly('Pack chinese bag', ['Wednesday']),
                createMorningWeekly('Pack swimming bag', ['Friday', 'Tuesday']),
                createMorningWeekly('Wear sports clothes', [
                    'Tuesday',
                    'Friday',
                ]),

                // Afternoon
                createDailyAfternoonChores('Unpack bag (especially lunch bag)'),
                createDailyAfternoonChores(
                    'Have a shower, cream and change into PJs'
                ),
                createDailyAfternoonChores('Do homework'),
                createDailyAfternoonChores('Put away clothes'),
                createDailyAfternoonChores('Ask Mummy if any other chores'),

                // Evening
                createDailyEveningChores('Brush your teeth'),
            ],
        } as ChoreList,
    ]
})

function createDailyMorningChores(description: string) {
    return createChore(description, 'morning', { $type: 'daily' })
}

function createDailyAfternoonChores(description: string) {
    return createChore(description, 'afternoon', { $type: 'daily' })
}

function createDailyEveningChores(description: string) {
    return createChore(description, 'evening', { $type: 'daily' })
}

function createMorningWeekly(description: string, daysOfWeeks: DayOfWeek[]) {
    return createChore(description, 'morning', {
        $type: 'weekly',
        daysOfWeek: daysOfWeeks,
    } as WeeklyFrequencyType)
}

function createMorningWeekDayChore(description: string) {
    return createChore(description, 'morning', {
        $type: 'weekly',
        daysOfWeek: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
    } as WeeklyFrequencyType)
}

function createAfternoonWeekDayChore(
    description: string,
    daysOfWeeks: DayOfWeek[]
) {
    return createChore(description, 'afternoon', {
        $type: 'weekly',
        daysOfWeek: daysOfWeeks,
    } as WeeklyFrequencyType)
}

function createChore(
    description: string,
    category: Category,
    frequencyType: FrequencyType
): Chore {
    return {
        category,
        frequencyType,
        description,
        isCompleted: false,
    }
}


jQuery(document).ready(function ($) {
    $('#UserNotAdded').multiselect({
        right: '#UserAdded, #UserResponsible',
        rightSelected: '#UserNotAdded_rightSelected, #UserNotAdded_rightSelected_2',
        leftSelected: '#UserNotAdded_leftSelected, #UserNotAdded_leftSelected_2',
        rightAll: '#UserNotAdded_rightAll, #UserNotAdded_rightAll_2',
        leftAll: '#UserNotAdded_leftAll, #UserNotAdded_leftAll_2',

        search: {
            left: '<input type="text" name="q" class="form-control" placeholder="' + searchLoc + '..." />'
        },

        moveToRight: function (Multiselect, $options, event, silent, skipStack) {
            var button = $(event.currentTarget).attr('id');

            if (button == 'UserNotAdded_rightSelected') {
                var $left_options = Multiselect.$left.find('> option:selected');
                Multiselect.$right.eq(0).append($left_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$right.eq(0).find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$right.eq(0));
                }
            } else if (button == 'UserNotAdded_rightAll') {
                var $left_options = Multiselect.$left.children(':visible');
                Multiselect.$right.eq(0).append($left_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$right.eq(0).find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$right.eq(0));
                }
            } else if (button == 'UserNotAdded_rightSelected_2') {
                var $left_options = Multiselect.$left.find('> option:selected');
                Multiselect.$right.eq(1).append($left_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$right.eq(1).find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$right.eq(1));
                }
            } else if (button == 'UserNotAdded_rightAll_2') {
                var $left_options = Multiselect.$left.children(':visible');
                Multiselect.$right.eq(1).append($left_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$right.eq(1).eq(1).find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$right.eq(1));
                }
            }
        },

        moveToLeft: function (Multiselect, $options, event, silent, skipStack) {
            var button = $(event.currentTarget).attr('id');

            if (button == 'UserNotAdded_leftSelected') {
                var $right_options = Multiselect.$right.eq(0).find('> option:selected');
                Multiselect.$left.append($right_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$left.find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$left);
                }
            } else if (button == 'UserNotAdded_leftAll') {
                var $right_options = Multiselect.$right.eq(0).children(':visible');
                Multiselect.$left.append($right_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$left.find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$left);
                }
            } else if (button == 'UserNotAdded_leftSelected_2') {
                var $right_options = Multiselect.$right.eq(1).find('> option:selected');
                Multiselect.$left.append($right_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$left.find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$left);
                }
            } else if (button == 'UserNotAdded_leftAll_2') {
                var $right_options = Multiselect.$right.eq(1).children(':visible');
                Multiselect.$left.append($right_options);

                if (typeof Multiselect.callbacks.sort == 'function' && !silent) {
                    Multiselect.$left.find('> option').sort(Multiselect.callbacks.sort).appendTo(Multiselect.$left);
                }
            }
        }
    });
});

















